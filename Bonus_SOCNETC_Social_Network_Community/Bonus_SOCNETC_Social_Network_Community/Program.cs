using System;
using System.Collections.Generic;

namespace Bonus_SOCNETC_Social_Network_Community
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);
            var q = int.Parse(Console.ReadLine());

            var communities = new Dictionary<int, List<int>>();

            for (var i = 1; i <= n; i++)
            {
                communities[i] = new List<int> { i };
            }

            for (var i = 0; i < q; i++)
            {
                var query = Console.ReadLine().Split(' ');

                switch (query[0])
                {
                    case "A":
                        var x = int.Parse(query[1]);
                        var y = int.Parse(query[2]);

                        if (communities[x].Contains(y))
                        {
                            break;
                        }

                        var community1 = communities[x];
                        var community2 = communities[y];
                        if (community1.Count + community2.Count > m)
                        {
                            break;
                        }

                        community1.AddRange(community2);
                        foreach (var user in community2)
                        {
                            communities[user] = community1;
                        }

                        break;

                    case "E":
                        x = int.Parse(query[1]);
                        y = int.Parse(query[2]);

                        if (communities[x].Contains(y))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }

                        break;

                    case "S":
                        x = int.Parse(query[1]);

                        Console.WriteLine(communities[x].Count);
                        break;
                }
            }
        }
    }
}