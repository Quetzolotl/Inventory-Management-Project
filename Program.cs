using Inventory_Management_Project;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inventory_Management_Project
{
    public class Program
    {
        // Moved fields/properties to above the constructor
        // Added access modifiers to all of the class level members (fields, properties, methods, etc)
        // Formatted the doc to have proper nesting indentation
        // Removed extra empty lines

        private string[] availableDifficulties = { "Easy", "Medium", "Hard", "Extreme" };
        private string[] storeLocations = { "Main Menu", "Shop", "Inventory", "Exit" };
        private string menuScreen = "";
        private int usersMoney = 0;
        private Random rnd = new Random();

        private User user = new User(0, null);

        private ShopOwner shopOwner = new ShopOwner(40000, null);

        private bool inGame = true;

        // Why is this the only one that is static?
        private static string json = File.ReadAllText("Data/npcInformation.json");

        private JObject dialog = JObject.Parse(json);

        private int[] StartMoney = { 1000, 750, 500, 250 };
        private int startingMoneyNumber = 0;

        private bool validDifficulty = false;

        [STAThread]
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.ChooseDifficulty();
        }

        private void LoadMenu()
        {
            for (int i = 0; i < storeLocations.Length; i++)
            {
                menuScreen += storeLocations[i];
                if (i < storeLocations.Length - 1)
                {
                    menuScreen += ", ";
                }
            }
        }

        private void ChooseDifficulty()
        {
            LoadMenu();

            while (!validDifficulty)
            {
                Console.Write("Welcome to Tal's Emperioum. Please select the difficutly. Easy, Medium, Hard, or Extreme. ->");

                string? difficultySelect = Console.ReadLine().Trim();

                string? firstLetterUpperDifficultySelect = char.ToUpper(difficultySelect[0]) + difficultySelect.Substring(1);

                if (Array.IndexOf(availableDifficulties, firstLetterUpperDifficultySelect) != -1)
                {
                    // User input is a valid difficulty level
                    Console.WriteLine("You have selected {0} difficulty level.", firstLetterUpperDifficultySelect);
                    validDifficulty = true;

                    if (firstLetterUpperDifficultySelect == null)
                    {
                        Console.WriteLine("Starting difficulty is null.");
                        return;
                    }
                    SetStartMoney(firstLetterUpperDifficultySelect);
                }
                else
                {
                    // User input is not a valid difficulty level
                    Console.WriteLine("{0} is not a valid difficulty level.", difficultySelect);
                }
            }
        }

        private void SetStartMoney(string startingDifficulty)
        {
            switch (startingDifficulty)
            {
                case "Easy":
                    startingMoneyNumber = 0;

                    break;

                case "Medium":
                    startingMoneyNumber = 1;
                    break;

                case "Hard":
                    startingMoneyNumber = 2;
                    break;

                case "Extreme":
                    startingMoneyNumber = 3;
                    break;
            }

            user.AddMoney(StartMoney[startingMoneyNumber]);
            Console.WriteLine($"Your adventure is just getting started! You have {user.Gold} gold pieces available.");

            StartGame();
        }

        private void StartGame()
        {
            while (inGame)
            {
                Console.Write($"Where would you like to go? {menuScreen} ->");

                string? whereToGo = Console.ReadLine().Trim();
                whereToGo = char.ToUpper(whereToGo[0]) + whereToGo.Substring(1);

                if (whereToGo == null)
                {
                    Console.WriteLine("Selection is null.");
                    return;
                }

                if (whereToGo == "Exit")
                {
                    Console.WriteLine("Exiting...Progress not saved!");
                    inGame = false; break;

                }
                else if (whereToGo == "Shop")
                {
                    // Console.WriteLine($"Should be opening shop ---------> {whereToGo}");
                    OpenShop();

                }
                else if (whereToGo == "Main Menu")
                {
                    MainMenu();
                }

                else if (whereToGo == "Inventory")
                {
                    OpenInventory();
                }
            }
        }

        private void MainMenu()
        {

        }

        private void OpenInventory()
        {

        }

        private void OpenShop()
        {
            //Console.WriteLine("Opening Shop");

            int randomGreeting = rnd.Next(0, 2);
            // Get the greeting for the shop owner
            string? greeting = dialog["blacksmith"]?["greetings"]?[randomGreeting]?.ToString();

            if (greeting != null)
            {
                Console.WriteLine($"{greeting}");
                Console.WriteLine("\r\n >Buy \r\n >Sell \r\n >Quest \r\n >Exit");
                string? userStoreSelect = Console.ReadLine()?.Trim();
                userStoreSelect = char.ToUpper(userStoreSelect[0]) + userStoreSelect.Substring(1);

                if (userStoreSelect != null)
                {
                    switch (userStoreSelect)
                    {
                        case "Buy":
                            shopOwner.OpenShop(user);
                            //perhaps write shop method here, but house most data in the shopowner file

                            Console.WriteLine("\r\nDoes anything look good to you? Type a number 1-14 to select the item and it's information, otherwise, type 'Back'");

                            //string? inShop = Console.ReadLine().ToUpper().Trim();
                            //int itemSelect;
                            //if (int.TryParse(inShop, out itemSelect))
                            //{


                            //    Console.WriteLine($"Ah! you have a good eye! {items[itemSelect].Name} is a beautiful blade.\r\nI've got {items[itemSelect].Quantity} in stock, and it's yours for the price of {items[itemSelect].Price} gold pieces.");
                            //    Console.WriteLine("Does it suit your fancy?");
                            //    string? userBuys = Console.ReadLine().Trim().ToUpper();



                            //    if (userBuys == "Yes")
                            //    {
                            //        //Weapon selectedItem = shopOwner[itemSele];

                            //       // break;
                            //    }
                            //}
                            break;
                        case "Sell":
                            shopOwner.SellWeapon(); break;
                        case "Quest":
                            shopOwner.OpenQuests(); break;
                        case "Exit":
                            shopOwner.Farewell();
                            break;
                    }
                }
            }
        }

        private void UserBuysWeapon(string itemToBuy, int itemCost, int itemLeft)
        {
            //first check if the user has enough gold
            if (itemCost > user.Gold)
            {
                Console.WriteLine("Sorry, friend. You don't have enough coin. I have other weapons that you could look at.");

            }
            else
            {
                user.RemoveMoney(itemCost);

                itemLeft--;
                // Console.WriteLine($"<------------------item: {itemToBuy} and left: {itemLeft}------->");
                Console.WriteLine($"Take good care of it! You now have {user.Gold} gold pieces.");

            }
        }
    }
}