using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efektywność_algorytmów_eksperyment
{
    public static class RandomNumberGenerator
    {
        public static int[] RadndomNumbersGenerator(int size, int minValue, int maxValue)
        {
            int[] tab = new int[size];
            for (int i = 0; i < size; i++)
                tab[i] = new Random().Next(minValue, maxValue);
            return tab;
        }

        public static int[] GenerateNumbersSorted(int size, int minValue, int maxValue)
        {
            int[] tab = RadndomNumbersGenerator(size, minValue, maxValue);
            Array.Sort(tab);
            return tab;
        }

        public static int[] GenerateNumbersReversed(int size, int minValue, int maxValue)
        {
            int[] tab = GenerateNumbersSorted(size, minValue, maxValue);
            Array.Reverse(tab);
            return tab;
        }

        public static int[] AlmostSorted(int size, int minValue, int maxValue)
        {
            int[] tab = RadndomNumbersGenerator(size, minValue, maxValue);

            Array.Sort(tab, 0, tab.Length/2);

            return tab;
        }

        public static int[] FewUnique(int size, int minValue, int maxValue)
        {
            int[] tab = RadndomNumbersGenerator(size, minValue, maxValue/5);
            return tab;
        }
    }
}