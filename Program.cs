using Inventory_Management_Project;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inventory_Management_Project
{
    // Added static to all of the class members to avoid the need to initialize an instance of this same class
    public class Program
    {
        // Encapsulate the information that is needed for the difficulties
        // This prevents the mismatching of data because you only have to find it once
        private static readonly DifficultyLevel[] difficulties =
        {
            new DifficultyLevel("Easy", 1000),
            new DifficultyLevel("Medium", 750),
            new DifficultyLevel("Hard", 500),
            new DifficultyLevel("Extreme", 200),
        };

        private static readonly string[] mainMenuOptions = { "Main Menu", "Shop", "Inventory", "Exit" };
        private static readonly string[] shopMenuOptions = { "Buy", "Sell", "Quest", "Exit" };

        private static readonly Random random = new Random();

        private static readonly User user = new User(0, null);
        private static readonly ShopOwner shopOwner = new ShopOwner(40000, null);
        private static JObject dialog;


        [STAThread]
        public static void Main(string[] args)
        {
            // The json is not used anywhere else, so it doesn't need to be a class level member
            // Variables should be scoped to just where they are needed
            var dialogJson = File.ReadAllText("Data/npcInformation.json");
            dialog = JObject.Parse(dialogJson);

            // The actual game functinality should be extracted into it's own class
            // This keeps the Program class clean and only responsible for starting the game
            // However, for the sake of the PR, I'm leaving it in the Program class
            ChooseDifficulty();
        }

        private static void ChooseDifficulty()
        {
            var isValidDifficulty = false;
            while (!isValidDifficulty)
            {
                Console.Write("Welcome to Tal's Emperioum. Please select the difficutly. Easy, Medium, Hard, or Extreme. ->");

                // The input selection can be cleaned up some
                // By doing the "?? string.Empty" we can avoid getting a null reference and makes future checks easier
                var userInput = Console.ReadLine()?.Trim() ?? string.Empty;

                // We can also use LINQ to make it easier to understand what is going on
                // We can also normalize the whole string by calling ToLower() or ToUpper() on it
                // This is easier to read and fixes a bug where if the user type eXit/EXIT/ExIt it would previously fail
                var matchingDifficulty = difficulties.FirstOrDefault(d => d.Label.ToLower() == userInput.ToLower());

                if (matchingDifficulty != null)
                {
                    // User input is a valid difficulty level
                    Console.WriteLine("You have selected {0} difficulty level.", matchingDifficulty.Label);
                    isValidDifficulty = true;

                    SetStartMoney(matchingDifficulty.StartingGold);
                }
                else
                {
                    // User input is not a valid difficulty level
                    Console.WriteLine("{0} is not a valid difficulty level.", userInput);
                }
            }
        }

        private static void SetStartMoney(int startingGold)
        {
            user.AddMoney(startingGold);

            // The things below here are not the responsibility of the SetStartMoney method
            // If you were to call this from another place (like a reset) it may be unexpected to tell the player they are just getting started
            Console.WriteLine($"Your adventure is just getting started! You have {user.Gold} gold pieces available.");

            StartGame();
        }

        private static void StartGame()
        {
            // Moved inGame variable into the same scope it is used
            var isInGame = true;
            while (isInGame)
            {
                Console.Write($"Where would you like to go? {string.Join(", ", mainMenuOptions)} ->");

                var userInput = Console.ReadLine()?.Trim() ?? string.Empty;
                userInput = userInput.ToLower();

                // Changed to a switch to improve readability and also handle invalid input better
                switch (userInput)
                {
                    case "exit":
                        Console.WriteLine("Exiting...Progress not saved!");
                        isInGame = false;
                        break;
                    case "shop":
                        OpenShop();
                        break;
                    case "main menu":
                        OpenMainMenu();
                        break;
                    case "inventory":
                        OpenInventory();
                        break;
                    default:
                        Console.WriteLine("That was an invalid command");
                        break;
                }
            }
        }

        // Renamed to match the pattern of the other options
        private static void OpenMainMenu()
        {

        }

        private static void OpenInventory()
        {

        }

        private static void OpenShop()
        {
            // This dialog stuff could be encapsulated into its own service
            // That would allow a developer to just call something like dialogService.GetRandomDialog("blacksmith:greetings", "Hello!") or similar
            // Added Index to the name, since it is not the actual random greeting
            var randomGreetingIndex = random.Next(0, 2);
            // Added a default greeting in case the dialog chain is incorrect/missing
            var greeting = dialog["blacksmith"]?["greetings"]?[randomGreetingIndex]?.ToString() ?? "Hello!";

            Console.WriteLine($"{greeting}");
            
            // Made this dynamic, though ultimately you would want to unify how all of the menus are displayed
            Console.WriteLine(" >" + string.Join($"{Environment.NewLine} >", shopMenuOptions));

            var userInput = Console.ReadLine()?.Trim() ?? string.Empty;
            userInput = userInput.ToLower();

            switch (userInput)
            {
                case "buy":
                    shopOwner.SellWeaponToUser(user);
                    break;
                case "sell":
                    shopOwner.BuyWeaponFromUser(); // Should take user but is not implemented yet
                    break;
                case "quest":
                    shopOwner.DisplayQuests();
                    break;
                case "exit":
                    shopOwner.BidFarewellToUser();
                    break;
            }
        }
    }
}