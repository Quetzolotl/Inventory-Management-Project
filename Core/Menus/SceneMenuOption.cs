using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core.Menus
{
    public struct SceneMenuOption : IMenuOption
    {
        public string Label { get; }
        public Type SceneType { get; }

        public SceneMenuOption(string label, Type sceneType)
        {
            Label = label;
            SceneType = sceneType;
        }
    }
}
