using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_SPOJ_KOIREP_Representatives
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, diff = int.MaxValue, l, r, x, lim, check = 0;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            List<KeyValuePair<int, int>> a = new List<KeyValuePair<int, int>>();
            int[] cnt = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    x = int.Parse(input[j]);
                    a.Add(new KeyValuePair<int, int>(x, i + 1));
                }
            }
            lim = n * m;
            l = r = 0;
            a.Sort();
            check = 1;
            cnt[a[0].Value]++;
            while (r < lim && l < lim)
            {
                if (check == n)
                {
                    diff = Math.Min(diff, a[r].Key - a[l].Key);
                    cnt[a[l].Value]--;
                    if (cnt[a[l].Value] == 0) check--;
                    l++;
                }
                else
                {
                    r++;
                    if (r == lim) break;
                    cnt[a[r].Value]++;
                    if (cnt[a[r].Value] == 1) check++;
                }
            }
            Console.WriteLine(diff);
        }
    }
}