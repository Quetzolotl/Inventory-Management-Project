using Inventory_Management_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class ShopScene : Scene
    {
        public ShopScene(SceneManager sceneManager, DisplayManager displayManager) : base(sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayWarning("Not Implemented");

            _displayManager.WaitForAnyInputFromPlayer(true);
        }
    }
}
