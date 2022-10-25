using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efektywność_algorytmów_eksperyment
{
    public class Enums
    {
        public enum TrialGroup
        {
            First,
            Second,
            Third,
            Fourth,
            Fifth,
            Sixth,
            Seventh,
            Eighth,
            Ninth,
            Tenth,
            Eleventh,
            Twelfth,
            Thirteenth,
            Fourteenth,
            Fifteenth
        }

        public enum SortName
        {
            [Description("Insertion sort")]
            InsertionSort,
            [Description("Merge sort")]
            MergeSort,
            [Description("Quick sort")]
            QuickSort,
            [Description("Array sort")]
            ArraySort
        }

        public enum TabDataName
        {
            [Description("Random")]
            Random,
            [Description("Sorted")]
            Sorted,
            [Description("Reversed")]
            Reversed,
            [Description("Almost sorted")]
            AlmostSorted,
            [Description("Few unique")]
            FewUnique,
        }

        public enum TrialSize
        {
            [Description("Small trial")]
            Small,
            [Description("Medium trial")]
            Medium,
            [Description("Large trial")]
            Large,
        }
    }
}