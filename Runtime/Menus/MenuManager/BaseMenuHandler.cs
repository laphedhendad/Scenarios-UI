using System;

namespace Laphed.ScenariosUI.Menus
{
    public abstract class BaseMenuHandler<TMenu>
        where TMenu : IMenu
    {
        internal readonly TMenu menu;
        private bool isConsumed;

        internal BaseMenuHandler(TMenu menu)
        {
            this.menu = menu;
        }

        protected void ResetInternal()
        {
            if (!isConsumed)
            {
                throw new Exception("Already reset");
            }

            isConsumed = false;
        }

        internal void Consume()
        {
            if (isConsumed)
            {
                throw new Exception("Already consumed");
            }

            isConsumed = true;
        }
    }
}
