using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_Project.Core.Menus;

namespace Inventory_Management_Project.Core
{
    public struct Difficulty
    {
        public enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard,
            Extreme
        }

        public DifficultyLevel Level { get; }
        public int StartingGold { get; }

        public Difficulty(DifficultyLevel level, int startingGold)
        {
            Level = level;
            StartingGold = startingGold;
        }
    }
}
