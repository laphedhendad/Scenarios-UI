using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    public interface IShowingMenuComponent
    {
        UniTask Show(int sortOrder);
        void ShowImmediately(int sortOrder);
    }
}
