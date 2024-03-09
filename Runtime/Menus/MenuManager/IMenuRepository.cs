namespace Laphed.ScenariosUI.Menus
{
    public interface IMenuRepository
    {
        TMenu Get<TMenu>() where TMenu : IMenu;
    }
}