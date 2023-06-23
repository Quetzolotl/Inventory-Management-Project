namespace Inventory_Management_Project.Core.Menus
{
    public struct GenericDataMenuOption<TData> : IMenuOption
    {
        public string Label { get; }
        public TData Data { get; }

        public GenericDataMenuOption(string label, TData data)
        {
            Label = label;
            Data = data;
        }
    }
}