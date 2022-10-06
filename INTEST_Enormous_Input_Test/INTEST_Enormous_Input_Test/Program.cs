using System;

namespace Intest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string linia = Console.ReadLine();
            string[] lines = linia.Split();
            int n = Convert.ToInt32(lines[0]);
            int k = Convert.ToInt32(lines[1]);
            int licznik = 0;
            for (int i = 0; i < n; i++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                if (x % k == 0)
                    licznik++;
            }
            Console.WriteLine(licznik);
        }
    }
}