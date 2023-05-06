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
        public enum Action { Buy, Sell }

        public IReadOnlyList<Weapon> Weapons => _weapons;

        private readonly List<Weapon> _weapons;
        private readonly Dictionary<Difficulty.DifficultyLevel, ShopRate> _rates;

        public WeaponShop(IDataManager dataManager)
        {
            var shopData = dataManager.LoadData<WeaponShopData>("weaponShop");

            _weapons = shopData?.Weapons?.ToList() ?? new List<Weapon>();
            _rates = shopData?.Rates ?? new Dictionary<Difficulty.DifficultyLevel, ShopRate>();
        }

        public void RemoveWeapon(Weapon weapon)
        {
            _weapons.Remove(weapon);
        }

        public void AddWeapon(Weapon selectedWeapon)
        {
            _weapons.Add(selectedWeapon);
        }

        public int GetAdjustedPrice(int originalPrice, Difficulty difficulty, Action action)
        {
            var rate = _rates[difficulty.Level];
            var modifier = action == Action.Buy ? rate.Buy : rate.Sell;

            return (int)Math.Round(originalPrice * modifier);
        }
    }
}
