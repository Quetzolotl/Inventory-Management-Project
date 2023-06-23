using Inventory_Management_Project.Core.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<GenericDataMenuOption<TData>> ToGenericDataMenuOptions<TData>(this IEnumerable<TData> collection, Func<TData, string> mapLabel)
        {
            return collection.Select(element => new GenericDataMenuOption<TData>(mapLabel(element), element));
        }
    }
}
