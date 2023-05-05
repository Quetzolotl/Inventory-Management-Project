using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project.Core.Menus;

namespace Inventory_Management_Project.Core
{
    public struct DifficultyLevel : IMenuOption
    {
        public string Label { get; }
        public int StartingGold { get; }

        public DifficultyLevel(string label, int startingGold)
        {
            Label = label;
            StartingGold = startingGold;
        }
    }
}
