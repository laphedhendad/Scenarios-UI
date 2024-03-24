using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Laphed.ScenariosUI.Menus.Mono
{
    [CreateAssetMenu(menuName = "Configs/MenuPrefabs", fileName = "MenuPrefabs")]
    public class MenuPrefabsRepository : ScriptableObject
    {
        public Dictionary<Type, BaseMenu> MenusPrefabs { get; private set; }

        [SerializeField] private List<BaseMenu> menusPrefabs = new();

        public void Initialize()
        {
            MenusPrefabs = menusPrefabs.ToDictionary(menu => menu.GetType(), menu => menu);
        }
    }
}
