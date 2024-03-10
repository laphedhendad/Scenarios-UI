using System;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.Menus
{
    interface IAsyncTransitionState
    {
        UniTask TransitionTask { get; }
    }

    abstract class BaseState
    {
        public abstract UniTask ShowMenu(int sortOrder);
        public abstract void ShowMenuImmediately(int sortOrder);
        public abstract void StashMenu();
        public abstract void UnStashMenu();
        public abstract UniTask HideMenu();
        public abstract void HideMenuImmediately();
        public abstract void SetSortOrder(int sortOrder);

        protected internal virtual void OnEnter() { }

        protected internal virtual void OnExit() { }

        protected Exception CreateException()
        {
            return new Exception($"{nameof(Menus)}: invalid menu state");
        }
    }
}
