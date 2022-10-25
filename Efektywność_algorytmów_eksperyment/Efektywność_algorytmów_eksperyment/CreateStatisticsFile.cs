using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efektywność_algorytmów_eksperyment
{
    public class CreateStatisticsFile
    {
        public void CreateFile(List<SortTestModel> sortingTests)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = path + "\\Statistics File.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    int testCase = 1;

                    for (int i = 0; i < 15; i++)
                    {
                        var testsInfo = sortingTests.Where(j => j.TrialGroup == (Enums.TrialGroup)i).ToList();
                        var testInfo = testsInfo.First();
                        sw.WriteLine($"Case {testCase}: {testInfo.TrialSize.DescriptionAttr()} (n = {testInfo.Size}), {testInfo.DataTabName.DescriptionAttr()}");

                        foreach (var test in testsInfo)
                        {
                            sw.WriteLine($"{test.SortName}: \n- Average time: {test.TestTime}\n- Standard deviation: {test.StandardDeviation}");
                        }

                        sw.WriteLine();
                        testCase++;
                    }

                }
            }

            using (StreamReader sr = File.OpenText(filepath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}