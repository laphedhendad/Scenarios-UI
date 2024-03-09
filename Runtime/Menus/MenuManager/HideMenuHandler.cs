namespace Laphed.ScenariosUI.Menus
{
    public class HideMenuHandler<TMenu> : BaseMenuHandler<TMenu>
        where TMenu : IMenu
    {
        public HideMenuHandler(TMenu menu)
            : base(menu) { }
    }
}
