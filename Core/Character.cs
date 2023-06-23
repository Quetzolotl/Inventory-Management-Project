namespace Inventory_Management_Project.Core
{
    public abstract class Character
    {
        public string Name { get; private set; } = string.Empty;

        public Character()
        {

        }

        public Character(string name)
        {
            Name = name;
        }

        public void AssignName(string name)
        {
            Name = name;
        }
    }
}