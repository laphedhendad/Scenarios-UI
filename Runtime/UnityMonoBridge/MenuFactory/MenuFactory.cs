using Laphed.ScenariosUI.DependencyInjection;
using UnityEngine;

namespace Laphed.ScenariosUI.Menus.Mono
{
    public class MenuFactory
        : MonoBehaviour,
          IMenuFactory
    {
        [SerializeField] private MenuPrefabsRepository menuPrefabsRepository;
        [Injection] private DependencyInjection.IController dependencyInjector;
        
        public TMenu Create<TMenu>()
            where TMenu : IMenu
        {
            BaseMenu menuPrefab = menuPrefabsRepository.MenusPrefabs[typeof(TMenu)];
            IMenu menu = Instantiate(menuPrefab, transform);
            
            BaseMenu monoMenu = (BaseMenu)menu;
            monoMenu.Construct();
            dependencyInjector.Inject(monoMenu);
            
            return (TMenu)menu;
        }
    }
}
