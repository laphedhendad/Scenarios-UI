using UnityEngine;

namespace Laphed.ScenariosUI.Menus.Mono
{
    public class MenuFactory
        : MonoBehaviour,
          IMenuFactory
    {
        [SerializeField] private MenuPrefabsRepository menuPrefabsRepository;

        public TMenu Create<TMenu>()
            where TMenu : IMenu
        {
            BaseMenu menuPrefab = menuPrefabsRepository.MenusPrefabs[typeof(TMenu)];
            IMenu menu = Instantiate(menuPrefab, transform);
            ((BaseMenu)menu).Construct();
            return (TMenu)menu;
        }
    }
}
