using System;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class MenuController : IMenuController
    {
        public bool IsHandleStashActivated => isHandleStashActivated;

        private readonly MenuStateMachine menuStateMachine;
        private bool isHandleStashActivated;

        public MenuController(MenuStateMachine menuStateMachine)
        {
            this.menuStateMachine = menuStateMachine;
        }

        public UniTask Show(int sortOrder)
        {
            return menuStateMachine.CurrentState.ShowMenu(sortOrder);
        }

        public void ShowImmediately(int sortOrder)
        {
            menuStateMachine.CurrentState.ShowMenuImmediately(sortOrder);
        }

        public UniTask Hide()
        {
            return menuStateMachine.CurrentState.HideMenu();
        }

        public void HideImmediately()
        {
            menuStateMachine.CurrentState.HideMenuImmediately();
        }

        public void Stash()
        {
            menuStateMachine.CurrentState.StashMenu();
        }

        public void UnStash()
        {
            menuStateMachine.CurrentState.UnStashMenu();
        }

        public void HandleStash()
        {
            if (isHandleStashActivated)
            {
                throw new Exception("handle stash already activated");
            }

            isHandleStashActivated = true;
            Stash();
        }

        public void HandleUnStash()
        {
            if (!isHandleStashActivated)
            {
                throw new Exception("handle stash is not active");
            }

            isHandleStashActivated = false;
            UnStash();
        }

        public void SetSortOrder(int sortOrder)
        {
            menuStateMachine.CurrentState.SetSortOrder(sortOrder);
        }
    }
}
