using Inventory_Management_Project.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core.Shops
{
    public sealed class WeaponShopData
    {
        public Dictionary<Difficulty.DifficultyLevel, ShopRate>? Rates { get; set; }
        public IEnumerable<Weapon>? Weapons { get; set; }
    }
}
