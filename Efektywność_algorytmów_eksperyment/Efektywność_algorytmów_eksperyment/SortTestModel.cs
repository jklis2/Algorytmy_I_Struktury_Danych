using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efektywność_algorytmów_eksperyment
{
    public class SortTestModel
    {
        public Enums.TrialGroup TrialGroup { get; set; }
        public Enums.SortName SortName { get; set; }
        public Enums.TabDataName DataTabName { get; set; }
        public Enums.TrialSize TrialSize { get; set; }
        public string TestTime { get; set; }
        public string StandardDeviation { get; set; }
        public int Size { get; set; }
    }
}