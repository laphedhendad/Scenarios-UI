using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class ShownState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly ICanvasOrderChangerMenuComponent canvasOrderChanger;

        public ShownState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            menuStateChanger = statesContext.MenuStateChanger;
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
            menuStateChanger.SetNextState(new StashingState(statesContext));
        }

        public override void UnStashMenu()
        {
            throw CreateException();
        }

        public override UniTask HideMenu()
        {
            var nextState = new HidingAsyncState(statesContext);
            menuStateChanger.SetNextState(nextState);
            return nextState.TransitionTask;
        }

        public override void HideMenuImmediately()
        {
            menuStateChanger.SetNextState(new HidingState(statesContext));
        }

        public override void SetSortOrder(int sortOrder)
        {
            canvasOrderChanger.SetSortOrder(sortOrder);
        }
    }
}
