using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class User
    {
        // Made setters private to avoid other outside the class from setting it
        public int Gold { get; private set; }
        public Weapon? Weapon { get; private set; } 

        public User(int gold,  Weapon? weapon)
        {
            Gold = gold;
            Weapon = weapon;
        }

        public void AddMoney(int gold)
        {
            Gold += gold;
        }

        public void RemoveMoney(int gold)
        {
            // Throw an exception if they pass in an invalid amount instead of just not doing anything
            // These could be added to other methods but I only did this once since it was the only one
            // with existing checks
            if (gold < 0) throw new ArgumentException("Cannot remove negative gold", nameof(gold));

            Gold -= gold;

            // Add protection to keep from going below zero gold
            if (Gold < 0)
            {
                Gold = 0;
            }
        }
    }
}
