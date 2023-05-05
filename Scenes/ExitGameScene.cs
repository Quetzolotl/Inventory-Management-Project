using Inventory_Management_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class ExitGameScene : Scene
    {
        public ExitGameScene(Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
        {
        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayMessage($"Thank you for playing the game, {_player.Name}! Have a good day!");

            _displayManager.WaitForAnyInputFromPlayer();
        }
    }
}
