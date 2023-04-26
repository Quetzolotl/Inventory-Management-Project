using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public sealed class DisplayManager
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayMessage(string message, bool hasNewLine = true)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            if (hasNewLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
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
