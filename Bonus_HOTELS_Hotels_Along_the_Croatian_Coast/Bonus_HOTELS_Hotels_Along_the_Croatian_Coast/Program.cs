using System;

public static class HOTELS
{
    public static long Solve(int hotelCount, int costLimit, int[] hotelCosts)
    {
        int startIndex = 0, endIndex = 0;
        long costFromStartToEnd = hotelCosts[0];
        long maximumCostFromStartToEnd = 0;

        while (true)
        {
            while (endIndex + 1 < hotelCount
                && costFromStartToEnd + hotelCosts[endIndex + 1] <= costLimit)
            {
                costFromStartToEnd += hotelCosts[++endIndex];
            }

            if (costFromStartToEnd < costLimit)
            {
                maximumCostFromStartToEnd = Math.Max(maximumCostFromStartToEnd, costFromStartToEnd);
            }
            else if (costFromStartToEnd == costLimit)
                return costLimit;

            if (endIndex + 1 == hotelCount)
                break;

            costFromStartToEnd -= hotelCosts[startIndex++];
            if (startIndex > endIndex)
            {
                endIndex = startIndex;
                costFromStartToEnd = hotelCosts[startIndex];
            }
        }

        return maximumCostFromStartToEnd;
    }
}

public static class Program
{
    private static void Main()
    {
        int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        int hotelCount = line[0];
        int costLimit = line[1];

        int[] hotelCosts = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);

        Console.WriteLine(
            HOTELS.Solve(hotelCount, costLimit, hotelCosts));
    }
}