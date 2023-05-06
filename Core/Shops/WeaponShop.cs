using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project.Core.Items;
using Inventory_Management_Project.Core.Managers;

namespace Inventory_Management_Project.Core.Shops
{
    public sealed class WeaponShop
    {
        public IReadOnlyList<Weapon> Weapons => _weapons;

        private readonly List<Weapon> _weapons;

        public WeaponShop(IDataManager dataManager)
        {
            _weapons = dataManager.LoadData<List<Weapon>>("weapons") ?? new List<Weapon>();
        }

        public void RemoveWeapon(Weapon weapon)
        {
            _weapons.Remove(weapon);
        }
    }
}
