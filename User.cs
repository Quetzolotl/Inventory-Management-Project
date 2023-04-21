using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class User

    {
        public int Gold { get; set; }
        public Weapon? Weapon { get; set; } 

        public User(int gold,  Weapon? weapon)
        {
            Gold = gold;
            Weapon = weapon;
        }

        public void BuyWeapon(Weapon weapon, int gold)
        {
            RemoveMoney(gold);
            Weapon = weapon;

            Console.WriteLine($"You now have {Gold} gold pieces");
        }

        public void AddMoney(int gold)
        {
            Gold += gold;
        }

        public void RemoveMoney(int gold)
        {
            if (gold > 0)
            {
                Gold -= gold;
            }
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Weapon = null;
            
        }
    }
}
