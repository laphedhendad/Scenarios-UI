using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class StashedState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly ICanvasOrderChangerMenuComponent canvasOrderChanger;

        public StashedState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            menuStateChanger = statesContext.MenuStateChanger;
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
            menuStateChanger.SetNextState(new UnStashingState(statesContext));
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
