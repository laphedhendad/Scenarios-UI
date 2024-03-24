using UnityEngine;

namespace Laphed.ScenariosUI.Menus.Mono
{
    [RequireComponent(typeof(MenuActivityBase))]
    public class BaseMenu : MonoBehaviour, IMenu
    {
        IMenuController IMenu.Controller => menuController;

        private MenuController menuController;

        internal void Construct()
        {
            var activityMenuComponent = GetComponent<MenuActivityBase>();
            activityMenuComponent.Construct();

            var menuNextStateRepository = new MenuNextStateRepository();
            var statesContext = new StatesContext(menuNextStateRepository, activityMenuComponent);
            var menuStateMachine = new MenuStateMachine(menuNextStateRepository, new HiddenState(statesContext));

            menuController = new MenuController(menuStateMachine);
        }

        public bool Equals(IMenu other)
        {
            if (other is MonoBehaviour monoOther)
            {
                return monoOther.GetInstanceID() == GetInstanceID();
            }

            return false;
        }
    }
}
