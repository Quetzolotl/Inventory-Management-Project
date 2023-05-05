using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project.Core;

namespace Inventory_Management_Project.Scenes
{
    public abstract class Scene
    {
        protected readonly SceneManager _sceneManager;
        protected readonly DisplayManager _displayManager;

        public Scene(SceneManager sceneManager, DisplayManager displayManager)
        {
            _sceneManager = sceneManager;
            _displayManager = displayManager;
        }

        public abstract void Draw();
    }
}
