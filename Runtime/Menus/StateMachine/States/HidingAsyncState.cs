using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class HidingAsyncState
        : BaseState,
          IAsyncTransitionState
    {
        public UniTask TransitionTask { get; private set; }

        private readonly StatesContext statesContext;
        private readonly IHidingMenuComponent hidingMenuComponent;
        private readonly IMenuStateChanger menuStateChanger;

        public HidingAsyncState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
            hidingMenuComponent = statesContext.HidingMenuComponent;
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
            await hidingMenuComponent.Hide();
            menuStateChanger.SetNextState(new HiddenState(statesContext));
        }
    }
}
