using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Level { get; set; }

        public Weapon(string name, int price, int quantity, int level)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Level = level;
        }
    }
}
