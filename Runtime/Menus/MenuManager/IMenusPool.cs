namespace Laphed.ScenariosUI.Menus
{
    public interface IMenusPool
    {
        T Get<T>()
            where T : IMenu;

        void Return(IMenu menu);
    }
}