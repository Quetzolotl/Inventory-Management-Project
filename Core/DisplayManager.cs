using Inventory_Management_Project.Core.Menus;

namespace Inventory_Management_Project.Core
{
    public sealed class DisplayManager
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayMessage(string message, bool hasNewLine = true)
        {
            DisplayMessage(message, hasNewLine, ConsoleColor.Gray);
        }

        public void DisplayWarning(string message, bool hasNewLine = true)
        {
            DisplayMessage(message, hasNewLine, ConsoleColor.Yellow);
        }

        public void DisplayError(string message, bool hasNewLine = true)
        {
            DisplayMessage(message, hasNewLine, ConsoleColor.Red);
        }

        public void DisplayInfo(string message, bool hasNewLine = true)
        {
            DisplayMessage(message, hasNewLine, ConsoleColor.Cyan);
        }

        private void DisplayMessage(string message, bool hasNewLine, ConsoleColor messageColor)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;

            if (hasNewLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }

            Console.ForegroundColor = originalColor;
        }

        public void WaitForAnyInputFromPlayer(bool showMessage = false, string message = "")
        {
            if (showMessage)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Please press any key to continue...";
                }

                DisplayMessage(message);
            }

            Console.ReadKey();
        }

        public string? GetInputFromPlayer()
        {
            return Console.ReadLine();
        }

        public string GetValidInputFromPlayer(IEnumerable<string> validInputs, bool shouldNormalize = true, string invalidInputMessage = "")
        {
            var isInputValid = false;
            var input = string.Empty;

            do
            {
                input = GetInputFromPlayer();

                if (input == null)
                {
                    isInputValid = false;
                }
                else
                {
                    if (shouldNormalize)
                    {
                        isInputValid = validInputs.Any(i => i.Trim().ToLower() == input.Trim().ToLower());
                    }
                    else
                    {
                        isInputValid = validInputs.Any(i => i == input);
                    }
                }

                if (!isInputValid && !string.IsNullOrWhiteSpace(invalidInputMessage))
                {
                    if (invalidInputMessage.Contains("{0}"))
                    {
                        invalidInputMessage = string.Format(invalidInputMessage, input);
                    }

                    DisplayError(invalidInputMessage);
                }
            }
            while (!isInputValid);

            return input ?? string.Empty;
        }

        public TOption GetMenuOptionFromPlayer<TOption>(string menuTitle, IEnumerable<TOption> menuOptions) where TOption : IMenuOption
        {
            DisplayMessage(menuTitle);

            var optionId = 0;
            var validOptions = new Dictionary<string, TOption>();

            foreach (var menuOption in menuOptions)
            {
                optionId++;
                validOptions.Add(optionId.ToString(), menuOption);

                DisplayMessage($"{optionId}: {menuOption.Label}");
            }

            var playerInput = GetValidInputFromPlayer(validOptions.Keys, true, "{0} is not a valid menu option. Please select another");

            return validOptions[playerInput];
        }


        public string GetMenuOptionFromPlayer(string menuTitle, IEnumerable<string> menuOptions)
        {
            var options = menuOptions.Select(m => new GenericMenuOption(m));

            var playerInput = GetMenuOptionFromPlayer(menuTitle, options);

            return playerInput.Label;
        }
    }
}
