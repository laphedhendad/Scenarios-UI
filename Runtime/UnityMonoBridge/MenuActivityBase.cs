using UnityEngine;

namespace Laphed.ScenariosUI.Menus.Mono
{
    [DisallowMultipleComponent]
    public abstract class MenuActivityBase
        : MonoBehaviour,
          IActivityMenuComponent
    {
        protected abstract IShowingMenuComponent ShowingMenuComponent { get; }
        protected abstract IHidingMenuComponent HidingMenuComponent { get; }
        protected abstract IStashingMenuComponent StashingMenuComponent { get; }
        protected abstract IUnStashingMenuComponent UnStashingMenuComponent { get; }
        protected abstract ICanvasOrderChangerMenuComponent CanvasOrderChangerMenuComponent { get; }
        protected internal abstract void Construct();

        IShowingMenuComponent IActivityMenuComponent.ShowingMenuComponent => ShowingMenuComponent;

        IHidingMenuComponent IActivityMenuComponent.HidingMenuComponent => HidingMenuComponent;

        IStashingMenuComponent IActivityMenuComponent.StashingMenuComponent => StashingMenuComponent;

        IUnStashingMenuComponent IActivityMenuComponent.UnStashingMenuComponent => UnStashingMenuComponent;

        ICanvasOrderChangerMenuComponent IActivityMenuComponent.CanvasOrderChangerMenuComponent =>
            CanvasOrderChangerMenuComponent;
    }
}
