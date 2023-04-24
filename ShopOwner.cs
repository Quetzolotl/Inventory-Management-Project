using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project;

namespace Inventory_Management_Project
{
    public class ShopOwner : User
    {
        // Changed the name since it can only hold Weapons
        private readonly List<Weapon> weapons = new List<Weapon>();

        public ShopOwner(int gold, Weapon? weapon) : base(gold, weapon)
        {
            // Could be replaced with a json file instead and simplify all of this
            // In practice, CSV can be very complicated to parse and map
            var weaponTextLines = File.ReadAllLines("Data/weapons.txt");

            // If this is in the constructor, when would weapons.Count ever be > 0?
            if (weapons.Count == 0)
            {
                foreach (var weaponTextLine in weaponTextLines)
                {
                    var fields = weaponTextLine.Split(',');
                    var name = "Unknown";
                    var price = 0;
                    var quantity = 0;
                    var level = 0;

                    // Need to check if there are actually enough fields to access
                    if (fields.Length > 0)
                    {
                        name = fields[0];
                    }

                    if (fields.Length > 1)
                    {
                        // Make sure the field is actually a int value
                        // It will default to 0 from above
                        int.TryParse(fields[1], out price);
                    }

                    if (fields.Length > 2)
                    {
                        int.TryParse(fields[2], out quantity);
                    }

                    if (fields.Length > 3)
                    {
                        int.TryParse(fields[3], out level);
                    }

                    weapons.Add(new Weapon(name, price, quantity, level));
                }
            }
        }

        public void SellWeaponToUser(User user)
        {
            Console.WriteLine("Have a look at my wares.");

            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i}: {weapons[i].Name}");
            }

            Console.WriteLine($"{Environment.NewLine}Does anything catch your eye? Type their respective item number to select the item and it's information, otherwise, type 'Back'");


            var userInput = Console.ReadLine()?.Trim() ?? string.Empty;
            userInput = userInput.ToLower();

            if (userInput == "back") // Check the most specific first, then work towards more generic
            {
                BidFarewellToUser();
            }
            else if (int.TryParse(userInput, out int selectedItemIndex) && weapons.Count > selectedItemIndex) // Make sure it's valid and in range
            {
                var shouldCloseShop = false; // Move these to be next to where they are used (or at least in the same "scope")
                while (!shouldCloseShop)
                {
                    var weapon = weapons[selectedItemIndex]; // Cache it so you don't have to keep accessing the array

                    Console.WriteLine($"Ah! you have a good eye! {weapon.Name} is a beautiful blade.{Environment.NewLine}I've got {weapon.Quantity} in stock, and it's yours for the price of {weapon.Price} gold pieces.");
                    Console.WriteLine("Does it suit your fancy? Yes or No"); // Added options

                    var userBuys = Console.ReadLine()?.Trim() ?? string.Empty;
                    userBuys = userBuys.ToLower();

                    if (userBuys == "yes")
                    {
                        if (weapon.Price > user.Gold)
                        {
                            Console.WriteLine("Sorry, friend. You don't have enough coin. I have other weapons that you could look at.");
                        }
                        else
                        {
                            user.RemoveMoney(weapon.Price);

                            if (weapon.Quantity > 0)
                            {
                                weapon.Quantity--; // Why is this being accessed directly but the user gold is set via a method?
                                Console.WriteLine($"<------------------item: {weapon.Name} and left: {weapon.Quantity}------->");
                                Console.WriteLine($"Take good care of it! You now have {user.Gold} gold pieces.");
                            }

                            if (weapon.Quantity <= 0)
                            {
                                weapons.Remove(weapon);
                            }

                            shouldCloseShop = true;

                            BidFarewellToUser();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, I don't have that in stock.");
            }
        }

        public void BidFarewellToUser()
        {
            Console.WriteLine("Farewell!");
        }

        internal void DisplayQuests()
        {
            // Why are these throwing an exception when the OpenMainMenu and OpenInventory methods in Program are just empty?
            throw new NotImplementedException();
        }

        internal void BuyWeaponFromUser()
        {
            throw new NotImplementedException();
        }
    }
}
