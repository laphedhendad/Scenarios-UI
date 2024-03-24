namespace Laphed.ScenariosUI.Menus
{
    public interface IMenuFactory
    {
        public TMenu Create<TMenu>() where TMenu : IMenu;
    }
}
