using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms
{
    public static class CollectionExtensions
    {
        public static void Add(this IList list, IEnumerable toAdd)
        {
            foreach (var item in toAdd)
            {
                list.Add(item);
            }
        }
    }
}
