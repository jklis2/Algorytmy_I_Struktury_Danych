using System;
using System.Collections.Generic;

namespace BubbleSort
{
    class Program
    {
        static void Main()
        {
            var numbersTab = Console.ReadLine().Split();
            var sortingNumbers = Console.ReadLine().Split();
            List<int> firstNumbers = new List<int>();
            List<int> lastNumbers = new List<int>();
            List<int> toSorted = new List<int>();

            for (int i = 0; i < Int32.Parse(sortingNumbers[0]); i++)
            {
                firstNumbers.Add(Int32.Parse(numbersTab[i]));
            }
            for (int i = Int32.Parse(sortingNumbers[0]); i <= Int32.Parse(sortingNumbers[1]); i++)
            {
                toSorted.Add(Int32.Parse(numbersTab[i]));
            }
            for (int i = Int32.Parse(sortingNumbers[1]) + 1; i < numbersTab.Length; i++)
            {
                lastNumbers.Add(Int32.Parse(numbersTab[i]));
            }

            int temp = 0;
            for (int i = 0; i < toSorted.Count - 1; i++)
            {
                for (int j = 0; j < toSorted.Count - 1 - i; j++)
                {
                    if (toSorted[j] < toSorted[j + 1])
                    {
                        temp = toSorted[j];
                        toSorted[j] = toSorted[j + 1];
                        toSorted[j + 1] = temp;
                    }
                }
            }

            foreach (var first in firstNumbers)
            {
                Console.Write(first + " ");
            }
            foreach (var sortedItem in toSorted)
            {
                Console.Write(sortedItem + " ");
            }
            foreach (var last in lastNumbers)
            {
                Console.Write(last + " ");
            }
        }
    }
}