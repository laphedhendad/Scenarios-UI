using System;

namespace Laphed.ScenariosUI.Menus
{
    public interface IMenu : IEquatable<IMenu>
    {
        internal IMenuController Controller { get; }
    }

    public interface IPreparableMenu
    {
        void Prepare();
    }

    public interface IPreparableMenu<T>
    {
        void Prepare(T context);
    }
}
