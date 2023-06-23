using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class Weapon
    {
        // Made setters private to avoid other outside the class from setting it
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Level { get; private set; }

        // This would probably make more sense to extract out to the User class
        // Right now, every user that has an instance of this weapon will share the same quantity
        // This would help decouple the "template" data (name, price, description, etc) from the "instance" data (quantity, durability, mods, etc)
        public int Quantity { get; set; }

        public Weapon(string name, int price, int quantity, int level)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Level = level;
        }
    }
}
