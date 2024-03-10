using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class UnStashingState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly IUnStashingMenuComponent unStashingMenuComponent;
        private readonly ICanvasOrderChangerMenuComponent canvasOrderChanger;

        public UnStashingState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            menuStateChanger = statesContext.MenuStateChanger;
            unStashingMenuComponent = statesContext.UnStashingMenuComponent;
            canvasOrderChanger = statesContext.CanvasOrderChangerMenuComponent;
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
            canvasOrderChanger.SetSortOrder(sortOrder);
        }

        protected internal override void OnEnter()
        {
            unStashingMenuComponent.UnStash();
            menuStateChanger.SetNextState(new ShownState(statesContext));
        }
    }
}
