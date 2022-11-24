using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        int length = 101;

        for (int i = 1; i <= t; i++)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            var cases = new Dictionary<int, int>();

            int[] arr1 = new int[length];
            bool[] arr2 = new bool[length];
            int[] arr3 = new int[length];

            var travSeq = Console.ReadLine().Split(' ');

            for (int k = 1; k < n * 2; k++)
            {
                arr3[k] = int.Parse(travSeq[k - 1]);
            }

            for (int j = 1; j <= n * 2; ++j)
            {
                if (!arr2[arr3[j]])
                {
                    stack.Push(arr3[j]);
                    arr2[arr3[j]] = true;
                }
                else if (stack.Peek() != 1)
                {
                    stack.Pop();
                    arr1[stack.Peek()]++;
                }
            }
            Console.WriteLine($"Case {i}:");

            for (int x = 1; x <= n; ++x)
            {
                Console.WriteLine($"{x} -> {arr1[x]}");
            }


            for (int y = 1; y <= n; ++y)
            {
                if (cases.ContainsKey(arr1[y]))
                {
                    cases[arr1[y]]++;
                }
                else
                {
                    cases[arr1[y]] = 1;
                }
            }
            stack.Pop();

            Console.WriteLine();
        }
    }
}