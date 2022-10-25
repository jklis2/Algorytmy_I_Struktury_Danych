using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efektywność_algorytmów_eksperyment
{
    public static class Extensions
    {
        public static double StandardDeviation(this IEnumerable<double> sequence)
        {
            double average = sequence.Average();
            double sum = sequence.Sum(d => Math.Pow(d - average, 2));
            return Math.Sqrt((sum) / sequence.Count());
        }
    }
}