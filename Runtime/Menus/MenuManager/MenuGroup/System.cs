using System.Collections.Generic;

namespace Laphed.ScenariosUI.Menus.MenuGroup
{
    public class System
    {
        public Dictionary<string, Model> Groups => groups;

        private readonly Dictionary<string, Model> groups;

        public System(Dictionary<string, Config> groupConfigs)
        {
            groups = new Dictionary<string, Model>();

            int startingSortOrder = 0;

            foreach ((string key, Config config) in groupConfigs)
            {
                groups.Add(
                    key,
                    new Model
                    {
                        menuGroupConfig = config,
                        startingSortOrder = startingSortOrder
                    }
                );

                startingSortOrder += config.GroupSortOrderStep;
            }
        }
    }
}
