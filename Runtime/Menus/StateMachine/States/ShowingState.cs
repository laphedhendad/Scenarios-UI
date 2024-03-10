using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class ShowingState : BaseState
    {
        private readonly StatesContext statesContext;
        private readonly int sortOrder;
        private readonly IMenuStateChanger menuStateChanger;
        private readonly IShowingMenuComponent showingMenuComponent;

        public ShowingState(StatesContext statesContext, int sortOrder)
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

        protected internal override void OnEnter()
        {
            showingMenuComponent.ShowImmediately(sortOrder);
            menuStateChanger.SetNextState(new ShownState(statesContext));
        }
    }
}
