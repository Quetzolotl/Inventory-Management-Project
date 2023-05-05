using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public sealed class Player : Character
    {
        public int Gold { get; private set; }

        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public void RemoveGold(int amount)
        {
            Gold = Math.Max(0, Gold - amount);
        }
    }
}
