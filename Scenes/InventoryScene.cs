using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class InventoryScene : Scene
    {
        public InventoryScene(Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
        {
        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayMessage("Here is the contents of your Inventory:");

            _displayManager.DisplayEmptyLine();

            if (_player.Inventory.Any())
            {
                foreach (var item in _player.Inventory)
                {
                    _displayManager.DisplayMessage($"- {item.Name}");
                }
            }
            else
            {
                _displayManager.DisplayWarning("You don't have any items");
            }

            _displayManager.DisplayEmptyLine();

            _displayManager.WaitForAnyInputFromPlayer();

            _sceneManager.ChangeScene<MainMenuScene>();
        }
    }
}
