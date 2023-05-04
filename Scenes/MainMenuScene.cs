using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project.Core;

namespace Inventory_Management_Project.Scenes
{
    public sealed class MainMenuScene : Scene
    {
        public MainMenuScene(DisplayManager displayManager) : base("Main Menu", displayManager)
        {

        }

        public override void Draw()
        {
            _displayManager.Clear();

            _displayManager.DisplayMessage("Hello World!!");
            _displayManager.DisplayInfo("Hello World!!");
            _displayManager.DisplayWarning("Hello World!!");
            _displayManager.DisplayError("Hello World!!");

            _displayManager.WaitForAnyInput();
        }
    }
}
