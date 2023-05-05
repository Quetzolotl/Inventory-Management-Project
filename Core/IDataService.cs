using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public interface IDataService
    {
        TData? LoadData<TData>(string dataName);
    }
}
