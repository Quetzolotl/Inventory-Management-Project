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
        protected readonly Player _player;
        protected readonly SceneManager _sceneManager;
        protected readonly DisplayManager _displayManager;

        public Scene(Player player, SceneManager sceneManager, DisplayManager displayManager)
        {
            _player = player;
            _sceneManager = sceneManager;
            _displayManager = displayManager;
        }

        public virtual void Draw()
        {
            _displayManager.Clear();
        }
    }
}
