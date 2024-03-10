using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    public class MenuManager : IMenuManager
    {
        private class StackItem
        {
            public interface IState { }
            public class StartStackState : IState { }

            public class StashingRootMenuState : IState
            {
                public StackItem rootStackItem;
            }

            public class HidingState : IState { }

            public IMenu menu;
            public IState state;
        }

        private readonly IMenusPool menusPool;
        private readonly MenuGroup.Model menuGroupModel;
        private readonly List<StackItem> stackItems;
        private StackItem currentStackItem;

        public MenuManager(IMenusPool menusPool, MenuGroup.Model menuGroupModel)
        {
            this.menusPool = menusPool;
            this.menuGroupModel = menuGroupModel;
            stackItems = new List<StackItem>();
        }

        public async UniTask<ShowMenuResult<TMenu>> ShowMenu<TMenu>()
            where TMenu : IMenu
        {
            if (stackItems.Count >= menuGroupModel.menuGroupConfig.capacity)
            {
                throw new Exception("Menu capacity overflow");
            }

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;

            var newMenu = menusPool.Get<TMenu>();
            StackItem newStackItem = GenerateNewStackItem(newMenu, oldStackItem);

            if (newMenu is IPreparableMenu preparableMenu)
            {
                preparableMenu.Prepare();
            }

            RecalculateSortOrder();

            stackItems.Add(newStackItem);
            int newMenuStackIndex = stackItems.Count - 1;

            currentStackItem = newStackItem;

            await newMenu.Controller.Show(CalculateSortOrder(newMenuStackIndex));

            switch (newStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    IMenu oldMenu = stashingRootMenuState.rootStackItem.menu;

                    if (!oldMenu.Controller.IsHandleStashActivated)
                    {
                        oldMenu.Controller.Stash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ShowMenuResult<TMenu>
            {
                menu = newMenu,
                hideMenuHandler = new HideMenuHandler<TMenu>(newMenu),
                handleStashMenuHandler = new HandleStashMenuHandler<TMenu>(newMenu)
            };
        }

        public ShowMenuResult<TMenu> ShowMenuImmediately<TMenu>()
            where TMenu : IMenu
        {
            if (stackItems.Count >= menuGroupModel.menuGroupConfig.capacity)
            {
                throw new Exception("Menu capacity overflow");
            }

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;

            var newMenu = menusPool.Get<TMenu>();
            StackItem newStackItem = GenerateNewStackItem(newMenu, oldStackItem);

            if (newMenu is IPreparableMenu preparableMenu)
            {
                preparableMenu.Prepare();
            }

            RecalculateSortOrder();

            stackItems.Add(newStackItem);
            int newMenuStackIndex = stackItems.Count - 1;
            newMenu.Controller.ShowImmediately(CalculateSortOrder(newMenuStackIndex));
            currentStackItem = newStackItem;

            switch (newStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    IMenu stashedMenu = stashingRootMenuState.rootStackItem.menu;

                    if (!stashedMenu.Controller.IsHandleStashActivated)
                    {
                        stashedMenu.Controller.Stash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ShowMenuResult<TMenu>
            {
                menu = newMenu,
                hideMenuHandler = new HideMenuHandler<TMenu>(newMenu),
                handleStashMenuHandler = new HandleStashMenuHandler<TMenu>(newMenu)
            };
        }

        public async UniTask<ShowMenuResult<TMenu>> ShowMenu<TMenu, TContext>(TContext context)
            where TMenu : IMenu, IPreparableMenu<TContext>
        {
            if (stackItems.Count >= menuGroupModel.menuGroupConfig.capacity)
            {
                throw new Exception("Menu capacity overflow");
            }

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;

            var newMenu = menusPool.Get<TMenu>();
            StackItem newStackItem = GenerateNewStackItem(newMenu, oldStackItem);

            newMenu.Prepare(context);

            RecalculateSortOrder();

            stackItems.Add(newStackItem);
            int newMenuStackIndex = stackItems.Count - 1;

            await newMenu.Controller.Show(CalculateSortOrder(newMenuStackIndex));

            currentStackItem = newStackItem;

            switch (newStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    IMenu oldMenu = stashingRootMenuState.rootStackItem.menu;

                    if (!oldMenu.Controller.IsHandleStashActivated)
                    {
                        oldMenu.Controller.Stash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ShowMenuResult<TMenu>
            {
                menu = newMenu,
                hideMenuHandler = new HideMenuHandler<TMenu>(newMenu),
                handleStashMenuHandler = new HandleStashMenuHandler<TMenu>(newMenu)
            };
        }

        public ShowMenuResult<TMenu> ShowMenuImmediately<TMenu, TContext>(TContext context)
            where TMenu : IMenu, IPreparableMenu<TContext>
        {
            if (stackItems.Count >= menuGroupModel.menuGroupConfig.capacity)
            {
                throw new Exception("Menu capacity overflow");
            }

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;

            var newMenu = menusPool.Get<TMenu>();
            StackItem newStackItem = GenerateNewStackItem(newMenu, oldStackItem);

            newMenu.Prepare(context);

            RecalculateSortOrder();

            stackItems.Add(newStackItem);
            int newMenuStackIndex = stackItems.Count - 1;
            newMenu.Controller.ShowImmediately(CalculateSortOrder(newMenuStackIndex));
            currentStackItem = newStackItem;

            switch (newStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    IMenu oldMenu = stashingRootMenuState.rootStackItem.menu;

                    if (!oldMenu.Controller.IsHandleStashActivated)
                    {
                        oldMenu.Controller.Stash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ShowMenuResult<TMenu>
            {
                menu = newMenu,
                hideMenuHandler = new HideMenuHandler<TMenu>(newMenu),
                handleStashMenuHandler = new HandleStashMenuHandler<TMenu>(newMenu)
            };
        }

        public async UniTask HideCurrentMenu<TMenu>(HideMenuHandler<TMenu> hideMenuHandler)
            where TMenu : IMenu
        {
            ValidateMenuTypeWithCurrentMenu(hideMenuHandler.menu);
            hideMenuHandler.Consume();

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;
            StackItem newStackItem = null;

            switch (oldStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    newStackItem = stashingRootMenuState.rootStackItem;
                    IMenu newMenu = newStackItem.menu;

                    if (!newMenu.Controller.IsHandleStashActivated)
                    {
                        newMenu.Controller.UnStash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            oldStackItem.state = new StackItem.HidingState();
            currentStackItem = newStackItem;

            await oldStackItem.menu.Controller.Hide();

            menusPool.Return(oldStackItem.menu);
            stackItems.Remove(oldStackItem);
        }

        public void HideCurrentMenuImmediately<TMenu>(HideMenuHandler<TMenu> hideMenuHandler)
            where TMenu : IMenu
        {
            ValidateMenuTypeWithCurrentMenu(hideMenuHandler.menu);
            hideMenuHandler.Consume();

            StackItem oldStackItem = currentStackItem;
            currentStackItem = null;
            StackItem newStackItem = null;

            switch (oldStackItem.state)
            {
                case StackItem.StartStackState:
                    break;

                case StackItem.StashingRootMenuState stashingRootMenuState:
                    newStackItem = stashingRootMenuState.rootStackItem;
                    IMenu newMenu = newStackItem.menu;

                    if (!newMenu.Controller.IsHandleStashActivated)
                    {
                        newMenu.Controller.UnStash();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            oldStackItem.menu.Controller.HideImmediately();
            oldStackItem.state = new StackItem.HidingState();

            menusPool.Return(oldStackItem.menu);
            stackItems.Remove(oldStackItem);
            currentStackItem = newStackItem;
        }

        public HandleUnStashMenuHandler<TMenu> HandleStashCurrentMenu<TMenu>(
            HandleStashMenuHandler<TMenu> handleStashMenuHandler)
            where TMenu : IMenu
        {
            TMenu menu = handleStashMenuHandler.menu;

            ValidateMenuTypeWithCurrentMenu(menu);
            handleStashMenuHandler.Consume();

            menu.Controller.HandleStash();

            return new HandleUnStashMenuHandler<TMenu>(menu, handleStashMenuHandler);
        }

        public void HandleUnStashCurrentMenu<TMenu>(HandleUnStashMenuHandler<TMenu> handleUnStashMenuHandler)
            where TMenu : IMenu
        {
            TMenu menu = handleUnStashMenuHandler.menu;

            ValidateMenuTypeWithCurrentMenu(menu);
            handleUnStashMenuHandler.Consume();

            HandleStashMenuHandler<TMenu> handleStashMenuHandler = handleUnStashMenuHandler.HandleStashMenuHandler;

            handleStashMenuHandler.Reset();
            menu.Controller.HandleUnStash();
        }

        private void RecalculateSortOrder()
        {
            for (int i = 0; i < stackItems.Count; i++)
            {
                stackItems[i]
                   .menu.Controller.SetSortOrder(CalculateSortOrder(i));
            }
        }

        private int CalculateSortOrder(int stackIndex)
        {
            return menuGroupModel.startingSortOrder + stackIndex * menuGroupModel.menuGroupConfig.menuSortOrderStep;
        }

        private void ValidateMenuTypeWithCurrentMenu<TMenu>(TMenu menu)
            where TMenu : IMenu
        {
            if (!menu.Equals(currentStackItem.menu))
            {
                throw new Exception($"{nameof(Menus)}: Current and target menus is not equals")
                {
                    Data =
                    {
                        {
                            "CurrentMenuType", currentStackItem.menu.GetType()
                               .FullName
                        },
                        { "TargetHideMenuType", typeof(TMenu).FullName }
                    }
                };
            }
        }

        private static StackItem GenerateNewStackItem(IMenu menu, StackItem rootStackItem)
        {
            StackItem.IState newStackItemState;

            if (rootStackItem == null)
            {
                newStackItemState = new StackItem.StartStackState();
            }
            else
            {
                switch (rootStackItem.state)
                {
                    case StackItem.StartStackState:
                    case StackItem.StashingRootMenuState:
                        newStackItemState = new StackItem.StashingRootMenuState
                        {
                            rootStackItem = rootStackItem
                        };

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return new StackItem
            {
                menu = menu,
                state = newStackItemState
            };
        }
    }
}
