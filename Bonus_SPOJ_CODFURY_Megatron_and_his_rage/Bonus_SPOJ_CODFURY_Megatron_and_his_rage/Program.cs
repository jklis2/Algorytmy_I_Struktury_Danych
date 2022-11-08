using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_SPOJ_CODFURY_Megatron_and_his_rage
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string[] input = Console.ReadLine().Split(' ');
                int p = int.Parse(input[0]);
                int m = int.Parse(input[1]);
                int[] arr = new int[p + 9];
                int flag = 0;
                long sum = 0, max = -1, total = 99999999;
                long[] cumu = new long[p + 9];
                cumu[0] = 0;
                for (int i = 1; i <= p; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                    sum += arr[i];
                    cumu[i] = sum;
                }
                int p1 = 0, p2 = 0;
                sum = 0;
                for (int i = 1; i <= p; i++)
                {
                    if (flag == 1)
                        i--;
                    sum = cumu[i] - cumu[p1];
                    flag = 0;
                    if (sum > m)
                    {
                        flag = 1;
                        p1++;
                    }
                    if (max < (i - p1))
                    {
                        max = (i - p1);
                        total = sum;
                    }
                    else if (max == (i - p1))
                    {
                        if (total > sum)
                            total = sum;
                    }
                }
                if (max == 0)
                    total = 0;
                if (total == 99999999)
                    Console.WriteLine("0 0");
                else
                    Console.WriteLine(total + " " + max);
            }
        }
    }
}