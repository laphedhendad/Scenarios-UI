namespace Laphed.ScenariosUI.Menus
{
    public class HandleStashMenuHandler<TMenu> : BaseMenuHandler<TMenu>
        where TMenu : IMenu
    {
        public HandleStashMenuHandler(TMenu menu)
            : base(menu) { }

        public void Reset()
        {
            ResetInternal();
        }
    }
}
