using Laphed.ScenariosUI.Menus;
using Laphed.ScenariosUI.SingleActions;

namespace Laphed.ScenariosUI
{
    public class ScenariosContext
    {
        public readonly IMenuManager rootMenuManager;
        public readonly SingleActionsExecutor globalSingleActionsExecutor;
    }
}
