using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class ShowingAsyncState
        : BaseState,
          IAsyncTransitionState
    {
        public UniTask TransitionTask { get; private set; }

        private readonly StatesContext statesContext;
        private readonly int sortOrder;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly IShowingMenuComponent showingMenuComponent;

        public ShowingAsyncState(StatesContext statesContext, int sortOrder)
        {
            this.statesContext = statesContext;
            this.sortOrder = sortOrder;
            menuStateChanger = statesContext.MenuStateChanger;
            showingMenuComponent = statesContext.ShowingMenuComponent;
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
            throw CreateException();
        }

        protected internal override async void OnEnter()
        {
            await showingMenuComponent.Show(sortOrder);
            menuStateChanger.SetNextState(new ShownState(statesContext));
        }
    }
}
