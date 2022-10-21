using System;
using System.Collections.Generic;
using System.Linq;

public static class ARRAYSUB
{
    public static int[] Solve(int[] array, int k)
    {
        if (k == array.Length) return new[] { array.Max() };
        if (k == 1) return array;

        var leftLookingDominators = new LinkedList<int>();
        leftLookingDominators.AddFirst(array[k - 1]);

        for (int i = k - 2; i >= 0; --i)
        {
            if (array[i] >= leftLookingDominators.Last.Value)
            {
                leftLookingDominators.AddLast(array[i]);
            }
        }

        int subarrayCount = array.Length - k + 1;
        int[] subarrayMaximums = new int[subarrayCount];
        subarrayMaximums[0] = leftLookingDominators.Last.Value;

        for (int i = 1, j = k; i < subarrayCount; ++i, ++j)
        {
            int lostLeftValue = array[i - 1];
            int gainedRightValue = array[j];

            if (lostLeftValue == leftLookingDominators.Last.Value)
            {
                leftLookingDominators.RemoveLast();
            }

            if (gainedRightValue > leftLookingDominators.Last.Value)
            {
                leftLookingDominators.Clear();
                leftLookingDominators.AddFirst(gainedRightValue);
            }
            else
            {
                while (gainedRightValue > leftLookingDominators.First.Value)
                {
                    leftLookingDominators.RemoveFirst();
                }
                leftLookingDominators.AddFirst(gainedRightValue);
            }

            subarrayMaximums[i] = leftLookingDominators.Last.Value;
        }

        return subarrayMaximums;
    }
}

public static class Program
{
    private static void Main()
    {
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = Array.ConvertAll(
            Console.ReadLine().Split(default(char[]), StringSplitOptions.RemoveEmptyEntries),
            int.Parse);
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(
            string.Join(" ", ARRAYSUB.Solve(array, k)));
    }
}