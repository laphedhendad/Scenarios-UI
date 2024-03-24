using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    public struct ShowMenuResult<TMenu>
        where TMenu : IMenu
    {
        public TMenu menu;
        public HideMenuHandler<TMenu> hideMenuHandler;
        public HandleStashMenuHandler<TMenu> handleStashMenuHandler;
    }

    public interface IMenuManager
    {
        UniTask<ShowMenuResult<TMenu>> ShowMenu<TMenu>()
            where TMenu : IMenu;

        ShowMenuResult<TMenu> ShowMenuImmediately<TMenu>()
            where TMenu : IMenu;

        UniTask<ShowMenuResult<TMenu>> ShowMenu<TMenu, TContext>(TContext context)
            where TMenu : IMenu, IPreparableMenu<TContext>;

        ShowMenuResult<TMenu> ShowMenuImmediately<TMenu, TContext>(TContext context)
            where TMenu : IMenu, IPreparableMenu<TContext>;

        UniTask HideMenu<TMenu>(HideMenuHandler<TMenu> hideMenuHandler)
            where TMenu : IMenu;

        void HideMenuImmediately<TMenu>(HideMenuHandler<TMenu> hideMenuHandler)
            where TMenu : IMenu;

        HandleUnStashMenuHandler<TMenu> HandleStashCurrentMenu<TMenu>(
            HandleStashMenuHandler<TMenu> handleStashMenuHandler)
            where TMenu : IMenu;

        void HandleUnStashCurrentMenu<TMenu>(HandleUnStashMenuHandler<TMenu> handleUnStashMenuHandler)
            where TMenu : IMenu;
    }
}
