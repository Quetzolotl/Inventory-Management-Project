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
        private static Weapon? weapon;
        private string[] lines = File.ReadAllLines("Data/weapons.txt");

        private List<Weapon> items = new List<Weapon>();

        public ShopOwner(int gold, Weapon weapon) : base(gold, weapon)
        {
            if (items.Count == 0)
            {
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');
                    string name = fields[0];
                    int price = int.Parse(fields[1]);
                    int quantity = int.Parse(fields[2]);
                    int level = int.Parse(fields[3]);
                    items.Add(new Weapon(name, price, quantity, level));
                }
            }
        }

        public void OpenShop(User user)
        {
            //items.Clear();

            Console.WriteLine("Have a look at my wares.");

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i}: {items[i].Name}");
            }

            Console.WriteLine("\r\nDoes anything catch your eye? Type their respective item number to select the item and it's information, otherwise, type 'Back'");

            bool closeShop = false;

            string? inShop = Console.ReadLine().Trim();
            inShop = char.ToUpper(inShop[0]) + inShop[1..];

            Console.WriteLine($"<---------------------first call: User typed: {inShop}");

            if (int.TryParse(inShop, out int itemSelect) && inShop != "Back")
            {
                while (!closeShop)
                {
                    Console.WriteLine($"Ah! you have a good eye! {items[itemSelect].Name} is a beautiful blade.\r\nI've got {items[itemSelect].Quantity} in stock, and it's yours for the price of {items[itemSelect].Price} gold pieces.");
                    Console.WriteLine("Does it suit your fancy?");

                    string? userBuys = Console.ReadLine().Trim();
                    userBuys = char.ToUpper(userBuys[0]) + userBuys.Substring(1);

                    if (userBuys == "Yes")
                    {
                        Weapon selectedItem = items[itemSelect];

                        if (items[itemSelect].Price > user.Gold)
                        {
                            Console.WriteLine("Sorry, friend. You don't have enough coin. I have other weapons that you could look at.");
                        }
                        else
                        {
                            user.RemoveMoney(items[itemSelect].Price);

                            if (items[itemSelect].Quantity > 0)
                            {
                                items[itemSelect].Quantity--;
                                Console.WriteLine($"<------------------item: {items[itemSelect].Name} and left: {items[itemSelect].Quantity}------->");
                                Console.WriteLine($"Take good care of it! You now have {user.Gold} gold pieces.");
                            }

                            if (items[itemSelect].Quantity <= 0)
                            {
                                items.RemoveAt(itemSelect);
                            }

                            closeShop = true;

                            Farewell();
                        }
                    }
                }
            }
            else if (inShop == "Back")
            {
                Console.WriteLine($" <-----------------------------> user typed back: {inShop}");
                Farewell();
            }
            else
            {
                Console.WriteLine("Sorry, I don't have that in stock.");
            }
        }

        public void Farewell()
        {
            Console.WriteLine("Farewell!");
        }

        internal void OpenQuests()
        {
            throw new NotImplementedException();
        }

        internal void SellWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
