namespace Laphed.ScenariosUI.Menus
{
    public class HandleUnStashMenuHandler<TMenu> : BaseMenuHandler<TMenu>
        where TMenu : IMenu
    {
        public HandleStashMenuHandler<TMenu> HandleStashMenuHandler => handleStashMenuHandler;

        private readonly HandleStashMenuHandler<TMenu> handleStashMenuHandler;

        public HandleUnStashMenuHandler(TMenu menu, HandleStashMenuHandler<TMenu> handleStashMenuHandler)
            : base(menu)
        {
            this.handleStashMenuHandler = handleStashMenuHandler;
        }
    }
}
