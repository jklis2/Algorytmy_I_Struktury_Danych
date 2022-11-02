using System;

namespace CodeRunner_Maksymalna_suma_podtablicy_o_zadanym_rozmiarze
{
    internal class Program
    {
        static int MaxSum(int[] arr, int n, int k)
        {
            int sum = 0, p = 0;

            if (n == k)
            {
                foreach (var x in arr)
                {
                    sum += x;
                }    
            } 

            else
            {
                for (int i = 0; i < k; i++)
                {
                    p += arr[i];
                }

                for (int j = 0; j < (n - k); j++)
                {
                    int sumTemp = 0;
                    p = p - arr[j] + arr[j + k];
                    sumTemp = p;

                    if (sumTemp > sum) 
                    { 
                        sum = sumTemp; 
                    }
                }
            }
            return sum;
        }
    }
}