using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class MainMenuScene : Scene
    {
        public MainMenuScene(DisplayManager displayManager) : base("Main Menu", displayManager)
        {

        }

        public override void Draw()
        {
            Console.Clear();

            Console.WriteLine("Hello World!!");

            Console.ReadLine();
        }
    }
}
