using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonus_SPOJ_ADAUSORT_Ada_and_Unstable_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var dict = new Dictionary<int, int>(n);
            for (int i = 0; i < n; i++)
            {
                dict.Add(i + 1, arr[i]);
            }

            var sorted = dict.OrderBy(x => x, new CustomComparer()).Select(x => x.Key);
            Console.WriteLine(string.Join(" ", sorted));
        }
    }

    public class CustomComparer : IComparer<KeyValuePair<int, int>>
    {
        public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            if (x.Value > y.Value)
                return 1;
            if (x.Value == y.Value)
            {
                if (x.Key > y.Key) return -1;
            }
            if (x.Value < y.Value)
                return -1;
            return 1;
        }
    }
}