using System;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.Menus
{
    public class MenusPool : IMenusPool
    {
        private readonly IMenuFactory menuFactory;
        private readonly Dictionary<Type, List<IMenu>> menuMap;

        public MenusPool(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
            menuMap = new Dictionary<Type, List<IMenu>>();
        }

        public T Get<T>()
            where T : IMenu
        {
            Type menuType = typeof(T);

            if (menuMap.TryGetValue(menuType, out List<IMenu> cashedMenus))
            {
                if (cashedMenus.Count > 0)
                {
                    IMenu cashedMenu = cashedMenus[0];
                    cashedMenus.RemoveAt(0);
                    return (T)cashedMenu;
                }
            }
            else
            {
                menuMap.Add(menuType, new List<IMenu>());
            }

            var createdMenu = menuFactory.Create<T>();

            return createdMenu;
        }

        public void Return(IMenu menu)
        {
            Type menuType = menu.GetType();

            menuMap[menuType]
               .Add(menu);
        }
    }
}
