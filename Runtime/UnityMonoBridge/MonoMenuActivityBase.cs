using UnityEngine;

namespace Laphed.ScenariosUI.Menus
{
    public abstract class MonoMenuActivityBase
        : MonoBehaviour,
          IActivityMenuComponent
    {
        protected internal abstract void Construct();
        protected abstract IShowingMenuComponent ShowingMenuComponent { get; }
        protected abstract IHidingMenuComponent HidingMenuComponent { get; }
        protected abstract IStashingMenuComponent StashingMenuComponent { get; }
        protected abstract IUnStashingMenuComponent UnStashingMenuComponent { get; }
        protected abstract ICanvasOrderChangerMenuComponent CanvasOrderChangerMenuComponent { get; }

        IShowingMenuComponent IActivityMenuComponent.ShowingMenuComponent => ShowingMenuComponent;

        IHidingMenuComponent IActivityMenuComponent.HidingMenuComponent => HidingMenuComponent;

        IStashingMenuComponent IActivityMenuComponent.StashingMenuComponent => StashingMenuComponent;

        IUnStashingMenuComponent IActivityMenuComponent.UnStashingMenuComponent => UnStashingMenuComponent;

        ICanvasOrderChangerMenuComponent IActivityMenuComponent.CanvasOrderChangerMenuComponent =>
            CanvasOrderChangerMenuComponent;
    }
}
