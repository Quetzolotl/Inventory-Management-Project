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
        protected readonly DisplayManager _displayManager;

        public event Action? OnExitGameRequest;

        public string Name { get; }

        public Scene(string name, DisplayManager displayManager)
        {
            Name = name;

            _displayManager = displayManager;
        }

        public abstract void Draw();
    }
}
