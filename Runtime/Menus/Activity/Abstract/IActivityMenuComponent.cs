namespace Laphed.ScenariosUI.Menus
{
    interface IActivityMenuComponent
    {
        internal IShowingMenuComponent ShowingMenuComponent { get; }
        internal IHidingMenuComponent HidingMenuComponent { get; }
        internal IStashingMenuComponent StashingMenuComponent { get; }
        internal IUnStashingMenuComponent UnStashingMenuComponent { get; }
        internal ICanvasOrderChangerMenuComponent CanvasOrderChangerMenuComponent { get; }
    }
}
