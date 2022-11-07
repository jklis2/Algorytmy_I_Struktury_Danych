using System;
using System.Text;

public class Test
{
    public static void Main()
    {
        var numberOfLines = Convert.ToInt32(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < numberOfLines; i++)
        {
            var numbers = Array.ConvertAll(Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           ?? Array.Empty<string>(), int.Parse);
            builder.AppendLine($"{numbers[0] * numbers[1]}");
        }
        Console.WriteLine(builder);
    }
}