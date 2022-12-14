using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        int n, m, time, job;

        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] mainJobs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            time = 0;
            List<int> jobsList = new List<int>(mainJobs);

            while (jobsList.Count > 0)
            {
                job = jobsList[0];
                jobsList.RemoveAt(0);
                if (jobsList.Any(x => x > job))
                    jobsList.Add(job);
                else
                {
                    time++;
                    if (m == 0)
                        break;
                }
                m--;

                if (m < 0)
                    m = jobsList.Count - 1;
            }
            sb.AppendLine(time.ToString());
        }
        Console.WriteLine(sb.ToString());
    }
}