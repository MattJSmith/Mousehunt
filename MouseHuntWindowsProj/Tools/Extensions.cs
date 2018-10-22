using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHunt
{
    public static class Extensions
    {
        //https://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c
        public static ICollection<T> Clone<T>(this ICollection<T> listToClone)
        {
            var array = new T[listToClone.Count];
            listToClone.CopyTo(array, 0);
            return array.ToList();
        }
    }
}
