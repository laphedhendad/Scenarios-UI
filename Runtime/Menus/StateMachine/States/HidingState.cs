using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    class HidingState : BaseState
    {
        private readonly StatesContext statesContext;

        public HidingState(StatesContext statesContext)
        {
            this.statesContext = statesContext;
        }

        public override UniTask ShowMenu(int sortOrder)
        {
            throw new System.NotImplementedException();
        }

        public override void ShowMenuImmediately(int sortOrder)
        {
            throw new System.NotImplementedException();
        }

        public override void StashMenu()
        {
            throw new System.NotImplementedException();
        }

        public override void UnStashMenu()
        {
            throw new System.NotImplementedException();
        }

        public override UniTask HideMenu()
        {
            throw new System.NotImplementedException();
        }

        public override void HideMenuImmediately()
        {
            throw new System.NotImplementedException();
        }

        public override void SetSortOrder(int sortOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}
