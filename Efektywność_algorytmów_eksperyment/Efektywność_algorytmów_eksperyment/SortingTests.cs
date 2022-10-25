using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efektywność_algorytmów_eksperyment.SortingMethods;

namespace Efektywność_algorytmów_eksperyment
{
    public class SortingTests
    {
        public List<SortTestModel> Sortings = new List<SortTestModel>();
        public void SortingTest(int[] tab, Enums.TrialGroup trialGroup, Enums.TabDataName dataTabName, Enums.TrialSize trialSize, int size)
        { 
            InsertionSort(tab, trialGroup, dataTabName, trialSize, size); 
            MergenSort(tab, trialGroup, dataTabName, trialSize, size); 
            quickSort(tab, trialGroup, dataTabName, trialSize, size);
            ArraySort(tab, trialGroup, dataTabName, trialSize, size);
        }

        private void InsertionSort(int[] tab, Enums.TrialGroup trialGroup, Enums.TabDataName dataTabName, Enums.TrialSize trialSize, int size)
        {
            TimeSpan timeSpan = new TimeSpan();
            Stopwatch stopWatch = new Stopwatch();
            List<double> timeNumbers = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                var copyTab = tab.Clone() as int[];
                stopWatch.Start();
                new InsertionSort().insertionSort(copyTab);
                stopWatch.Stop();
                timeSpan += stopWatch.Elapsed;
                timeNumbers.Add(stopWatch.Elapsed.TotalMilliseconds);
            }

            var time = timeSpan / 10;
            var standardDeviation = timeNumbers.StandardDeviation();

            Sortings.Add(new SortTestModel
            {
                TrialGroup = trialGroup,
                SortName = Enums.SortName.InsertionSort,
                DataTabName = dataTabName,
                TrialSize = trialSize,
                TestTime = time.ToString(),
                StandardDeviation = standardDeviation.ToString(CultureInfo.InvariantCulture),
                Size = size
            });
        }

        private void MergenSort(int[] tab, Enums.TrialGroup trialGroup, Enums.TabDataName dataTabName, Enums.TrialSize trialSize, int size)
        {
            TimeSpan timeSpan = new TimeSpan();
            Stopwatch stopWatch = new Stopwatch();
            List<double> timeNumbers = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                var copyTab = tab.Clone() as int[];
                stopWatch.Start();
                new MergeSort().mergeSort(copyTab, 0, copyTab.Length - 1);
                stopWatch.Stop();
                timeSpan += stopWatch.Elapsed;
                timeNumbers.Add(stopWatch.Elapsed.TotalMilliseconds);
            }

            var time = timeSpan / 10;
            var standardDeviation = timeNumbers.StandardDeviation();

            Sortings.Add(new SortTestModel
            {
                TrialGroup = trialGroup,
                SortName = Enums.SortName.MergeSort,
                DataTabName = dataTabName,
                TrialSize = trialSize,
                TestTime = time.ToString(),
                StandardDeviation = standardDeviation.ToString(CultureInfo.InvariantCulture),
                Size = size
            });
        }

        private void quickSort(int[] tab, Enums.TrialGroup trialGroup, Enums.TabDataName dataTabName, Enums.TrialSize trialSize, int size)
        {
            TimeSpan timeSpan = new TimeSpan();
            Stopwatch stopWatch = new Stopwatch();
            List<double> timeNumbers = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                var copyTab = tab.Clone() as int[];
                stopWatch.Start();
                QuickSort.quickSort(copyTab, 0, copyTab.Length - 1);
                stopWatch.Stop();
                timeSpan += stopWatch.Elapsed;
                timeNumbers.Add(stopWatch.Elapsed.TotalMilliseconds);
            }

            var time = timeSpan / 10;
            var standardDeviation = timeNumbers.StandardDeviation();

            Sortings.Add(new SortTestModel
            {
                TrialGroup = trialGroup,
                SortName = Enums.SortName.QuickSort,
                DataTabName = dataTabName,
                TrialSize = trialSize,
                TestTime = time.ToString(),
                StandardDeviation = standardDeviation.ToString(CultureInfo.InvariantCulture),
                Size = size
            });
        }

        private void ArraySort(int[] tab, Enums.TrialGroup trialGroup, Enums.TabDataName dataTabName, Enums.TrialSize trialSize, int size)
        {
            TimeSpan timeSpan = new TimeSpan();
            Stopwatch stopWatch = new Stopwatch();
            List<double> timeNumbers = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                var copyTab = tab.Clone() as int[];
                stopWatch.Start();
                Array.Sort(copyTab);
                stopWatch.Stop();
                timeSpan += stopWatch.Elapsed;
                timeNumbers.Add(stopWatch.Elapsed.TotalMilliseconds);
            }

            var time = timeSpan / 10;
            var standardDeviation = timeNumbers.StandardDeviation();

            Sortings.Add(new SortTestModel
            {
                TrialGroup = trialGroup,
                SortName = Enums.SortName.ArraySort,
                DataTabName = dataTabName,
                TrialSize = trialSize,
                TestTime = time.ToString(),
                StandardDeviation = standardDeviation.ToString(CultureInfo.InvariantCulture),
                Size = size
            });
        }
    }
}