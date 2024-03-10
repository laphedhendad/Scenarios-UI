namespace Laphed.ScenariosUI.Menus
{
    class StatesContext
    {
        public IHidingMenuComponent HidingMenuComponent => activityMenuComponent.HidingMenuComponent;
        public IShowingMenuComponent ShowingMenuComponent => activityMenuComponent.ShowingMenuComponent;
        public IStashingMenuComponent StashingMenuComponent => activityMenuComponent.StashingMenuComponent;
        public IUnStashingMenuComponent UnStashingMenuComponent => activityMenuComponent.UnStashingMenuComponent;

        public ICanvasOrderChangerMenuComponent CanvasOrderChangerMenuComponent =>
            activityMenuComponent.CanvasOrderChangerMenuComponent;

        public IMenuStateChanger MenuStateChanger => menuStateChanger;

        private readonly IMenuStateChanger menuStateChanger;
        private readonly IActivityMenuComponent activityMenuComponent;

        public StatesContext(IMenuStateChanger menuStateChanger, IActivityMenuComponent activityMenuComponent)
        {
            this.menuStateChanger = menuStateChanger;
            this.activityMenuComponent = activityMenuComponent;
        }
    }
}
