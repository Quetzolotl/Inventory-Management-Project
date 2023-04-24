using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class DifficultyLevel
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
