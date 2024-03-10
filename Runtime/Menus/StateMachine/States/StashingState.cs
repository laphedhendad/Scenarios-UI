using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class StashingState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly IStashingMenuComponent stashingMenuComponent;

        public StashingState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            menuStateChanger = statesContext.MenuStateChanger;
            stashingMenuComponent = statesContext.StashingMenuComponent;
        }

        public override UniTask ShowMenu(int sortOrder)
        {
            throw CreateException();
        }

        public override void ShowMenuImmediately(int sortOrder)
        {
            throw CreateException();
        }

        public override void StashMenu()
        {
            throw CreateException();
        }

        public override void UnStashMenu()
        {
            throw CreateException();
        }

        public override UniTask HideMenu()
        {
            throw CreateException();
        }

        public override void HideMenuImmediately()
        {
            throw CreateException();
        }

        public override void SetSortOrder(int sortOrder)
        {
            statesContext.CanvasOrderChangerMenuComponent.SetSortOrder(sortOrder);
        }

        protected internal override void OnEnter()
        {
            stashingMenuComponent.Stash();
            menuStateChanger.SetNextState(new StashedState(statesContext));
        }
    }
}
