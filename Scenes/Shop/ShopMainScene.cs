using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Managers;
using Inventory_Management_Project.Core.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes.Shop
{
    public sealed class ShopMainScene : Scene
    {
        private enum ShopOption { Buy, Sell, Quest, Exit }

        private readonly List<SceneMenuOption> _menuOptions = new List<SceneMenuOption>()
        {
            new SceneMenuOption("Buy", typeof(ShopSellToPlayerScene)),
            new SceneMenuOption("Exit", typeof(MainMenuScene)),
        };

        public ShopMainScene(Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            base.Draw();

            var selectedOption = _displayManager.GetMenuOptionFromPlayer("Welcome to Kiu's Emporium, friend! What can I do for you?", _menuOptions);

            _sceneManager.ChangeScene(selectedOption.SceneType);
        }
    }
}
