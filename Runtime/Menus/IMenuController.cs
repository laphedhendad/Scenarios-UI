using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    interface IMenuController
    {
        UniTask Show(int sortOrder);
        void ShowImmediately(int sortOrder);
        UniTask Hide();
        void HideImmediately();
        void Stash();
        void UnStash();
        void HandleStash();
        void HandleUnStash();
        void SetSortOrder(int sortOrder);
        bool IsHandleStashActivated { get; }
    }
}
