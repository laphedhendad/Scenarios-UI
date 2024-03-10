using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class HiddenState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly IMenuStateChanger menuStateChanger;

        public HiddenState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            menuStateChanger = statesContext.MenuStateChanger;
        }

        public override UniTask ShowMenu(int sortOrder)
        {
            var nextState = new ShowingAsyncState(statesContext, sortOrder);
            menuStateChanger.SetNextState(nextState);
            return nextState.TransitionTask;
        }

        public override void ShowMenuImmediately(int sortOrder)
        {
            menuStateChanger.SetNextState(new ShowingState(statesContext, sortOrder));
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
            throw CreateException();
        }
    }
}
