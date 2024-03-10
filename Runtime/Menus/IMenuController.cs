using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    interface IMenuController
    {
        bool IsHandleStashActivated { get; }
        UniTask Show(int sortOrder);
        void ShowImmediately(int sortOrder);
        UniTask Hide();
        void HideImmediately();
        void Stash();
        void UnStash();
        void HandleStash();
        void HandleUnStash();
        void SetSortOrder(int sortOrder);
    }
}
