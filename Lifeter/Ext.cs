using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifeter
{
    internal static class Ext
    {
        public static string Form(this string source, params string[] par)
        {
            return string.Format(source, par);
        }
        public static void Move<T>(this List<T> list, int oldindex, int newindex)
        {
            T item = list[oldindex];

            list.RemoveAt(oldindex);
            list.Insert(newindex, item);
        }
        public static System.Drawing.Color ToColor(this int argb)
        {
            return System.Drawing.Color.FromArgb(argb);
        }
    }
}
