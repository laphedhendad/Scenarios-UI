namespace Laphed.ScenariosUI.Menus.MenuGroup
{
    public struct Config
    {
        public int GroupSortOrderStep => menuSortOrderStep * capacity;
        public int menuSortOrderStep;
        public int capacity;
    }
}
