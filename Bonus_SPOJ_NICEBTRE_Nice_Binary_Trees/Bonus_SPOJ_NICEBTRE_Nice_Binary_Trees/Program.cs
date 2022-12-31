using System;

namespace Bonus_SPOJ_NICEBTRE_Nice_Binary_Trees
{
    internal class Program
    {

        static int i = 0;
        static char[] str = new char[10000];
        static int max_lvl = 0;

        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                max_lvl = 0;
                i = -1;
                str = Console.ReadLine().ToCharArray();
                tree(0);
                Console.WriteLine(max_lvl);
            }
        }

        static void tree(int lvl)
        {
            i++;
            if (lvl > max_lvl) max_lvl = lvl;
            if (str[i] == '\0') return;
            if (str[i] == 'l') return;
            if (str[i] == 'n')
            {
                tree(lvl + 1);
                tree(lvl + 1);
            }
        }
    }
}