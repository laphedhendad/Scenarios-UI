using Example.PlayerComponents;
using Laphed.ScenariosUI.Menus;
using Laphed.ScenariosUI.SingleActions;
using MenuGroupConfigAlias = Laphed.ScenariosUI.Menus.MenuGroup;

namespace Laphed.ScenariosUI
{
    public class ScenariosContext
    {
        public Player player;
        public IMenuManager rootMenuManager;
        public SingleActionsExecutor singleActionsExecutor;
        public MenuGroupConfigAlias.System menuGroupsConfig;
    }
}
