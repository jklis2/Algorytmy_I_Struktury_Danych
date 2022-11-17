using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKS___RK_Sorting
{
    class Program
    {
        public static void Solve(int N, int C, List<int> list)
        {
            Dictionary<int, int> F = new Dictionary<int, int>();
            int currentCount;
            foreach (int i in list)
            {
                if (F.ContainsKey(i))
                {
                    F.TryGetValue(i, out currentCount);
                    F[i] = currentCount + 1;
                }
                else
                {
                    F.Add(i, 1);
                }
            }
            F = F.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            for (int j = 0; j < F.Count; j++)
            {
                for (int k = 0; k < F.ElementAt(j).Value; k++)
                {
                    Console.Write($"{F.ElementAt(j).Key} ");
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var firstLineInput = (Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse));
            int N = firstLineInput[0];
            int C = firstLineInput[1];
            List<int> list = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(convertTemp => Convert.ToInt32(convertTemp)).ToList();
            Solve(N, C, list);
        }
    }
}