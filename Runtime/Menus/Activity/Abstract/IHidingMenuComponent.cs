using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    public interface IHidingMenuComponent
    {
        UniTask Hide();
        void HideImmediately();
    }
}
