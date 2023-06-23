using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DifficultyLevel Level { get; set; }
        public string DisplayName { get; set; }

        public int StartingGold { get; set; }
    }
}
