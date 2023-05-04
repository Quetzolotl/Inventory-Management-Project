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

        public void WaitForAnyInput()
        {
            Console.ReadKey();
        }

        public string? GetInput()
        {
            return Console.ReadLine();
        }

        public string GetValidInput(IEnumerable<string> validInputs, bool shouldNormalize = true, string invlidInputMessage = "")
        {
            var isInputValid = false;

            do
            {
                var input = GetInput();

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

                if (!isInputValid && !string.IsNullOrWhiteSpace(invlidInputMessage))
                {

                }
            }
            while (true);
        }
    }
}
