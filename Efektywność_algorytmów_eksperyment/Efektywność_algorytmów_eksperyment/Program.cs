using Efektywność_algorytmów_eksperyment;
using System;
using Efektywność_algorytmów_eksperyment.SortingMethods;

int small = 10;
int medium = 1000;
int large = 10000;

var smallRandomTab = RandomNumberGenerator.RadndomNumbersGenerator(small, 0, 10);
var mediumRandomTab = RandomNumberGenerator.RadndomNumbersGenerator(medium, 0, 1000);
var largeRandomTab = RandomNumberGenerator.RadndomNumbersGenerator(large, 0, 10000);

var smallSortedTab = RandomNumberGenerator.GenerateNumbersSorted(small, 0, 10);
var mediumSortedTab = RandomNumberGenerator.GenerateNumbersSorted(medium, 0, 1000);
var largeSortedTab = RandomNumberGenerator.GenerateNumbersSorted(large, 0, 10000);

var smallReversedTab = RandomNumberGenerator.GenerateNumbersReversed(small, 0, 10);
var mediumReversedTab = RandomNumberGenerator.GenerateNumbersReversed(medium, 0, 1000);
var largeReversedTab = RandomNumberGenerator.GenerateNumbersReversed(large, 0, 10000);

var smallAlmostSorted = RandomNumberGenerator.AlmostSorted(small, 0 ,10);
var mediumAlmostSorted = RandomNumberGenerator.AlmostSorted(medium, 0, 1000);
var largeAlmostSorted = RandomNumberGenerator.AlmostSorted(large, 0, 10000);

var smallFewUnique = RandomNumberGenerator.FewUnique(small, 0, 10);
var mediumFewUnique = RandomNumberGenerator.FewUnique(medium, 0, 1000);
var largeFewUnique = RandomNumberGenerator.FewUnique(large, 0, 10000);

SortingTests sortingTests = new SortingTests();

sortingTests.SortingTest(smallRandomTab, Enums.TrialGroup.First, Enums.TabDataName.Random, Enums.TrialSize.Small, small);
sortingTests.SortingTest(mediumRandomTab, Enums.TrialGroup.Second, Enums.TabDataName.Random, Enums.TrialSize.Medium, medium);
sortingTests.SortingTest(largeRandomTab, Enums.TrialGroup.Third, Enums.TabDataName.Random, Enums.TrialSize.Large, large);

sortingTests.SortingTest(smallSortedTab, Enums.TrialGroup.Fourth, Enums.TabDataName.Sorted, Enums.TrialSize.Small, small);
sortingTests.SortingTest(mediumSortedTab, Enums.TrialGroup.Fifth, Enums.TabDataName.Sorted, Enums.TrialSize.Medium, medium);
sortingTests.SortingTest(largeSortedTab, Enums.TrialGroup.Sixth, Enums.TabDataName.Sorted, Enums.TrialSize.Large, large);

sortingTests.SortingTest(smallReversedTab, Enums.TrialGroup.Seventh, Enums.TabDataName.Reversed, Enums.TrialSize.Small, small);
sortingTests.SortingTest(mediumReversedTab, Enums.TrialGroup.Eighth, Enums.TabDataName.Reversed, Enums.TrialSize.Medium, medium);
sortingTests.SortingTest(largeReversedTab, Enums.TrialGroup.Ninth, Enums.TabDataName.Reversed, Enums.TrialSize.Large, large);

sortingTests.SortingTest(smallAlmostSorted, Enums.TrialGroup.Tenth, Enums.TabDataName.AlmostSorted, Enums.TrialSize.Small, small);
sortingTests.SortingTest(mediumAlmostSorted, Enums.TrialGroup.Eleventh, Enums.TabDataName.AlmostSorted, Enums.TrialSize.Medium, medium);
sortingTests.SortingTest(largeAlmostSorted, Enums.TrialGroup.Twelfth, Enums.TabDataName.AlmostSorted, Enums.TrialSize.Large, large);

sortingTests.SortingTest(smallFewUnique, Enums.TrialGroup.Thirteenth, Enums.TabDataName.FewUnique, Enums.TrialSize.Small, small);
sortingTests.SortingTest(mediumFewUnique, Enums.TrialGroup.Fourteenth, Enums.TabDataName.FewUnique, Enums.TrialSize.Medium, medium);
sortingTests.SortingTest(largeFewUnique, Enums.TrialGroup.Fifteenth, Enums.TabDataName.FewUnique, Enums.TrialSize.Large, large);

new CreateStatisticsFile().CreateFile(sortingTests.Sortings);