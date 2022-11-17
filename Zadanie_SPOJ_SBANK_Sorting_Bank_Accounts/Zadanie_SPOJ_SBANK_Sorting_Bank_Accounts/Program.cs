using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBANK___Sorting_Bank_Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                var accs = new Dictionary<string, int>();

                for (int j = 0; j < n; j++)
                {
                    string newAcc = Console.ReadLine();
                    if (!accs.TryAdd(newAcc, 1))
                    {
                        accs[newAcc]++;
                    }
                }

                Console.ReadLine();
                foreach (var item in new SortedDictionary<string, int>(accs))
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}