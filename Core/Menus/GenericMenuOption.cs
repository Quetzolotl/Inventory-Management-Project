namespace Inventory_Management_Project.Core.Menus
{
    public struct GenericMenuOption : IMenuOption
    {
        public string Label { get; }

        public GenericMenuOption(string label)
        {
            Label = label;
        }
    }
}