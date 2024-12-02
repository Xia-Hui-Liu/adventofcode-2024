using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2024");
        Console.WriteLine("Enter the day to solve (1-25):");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int day) && day >= 1 && day <= 25)
        {
            SolveDay(day);
        }
        else
        {
            Console.WriteLine("Invalid day. Please enter a number between 1 and 25.");
        }
    }

    static void SolveDay(int day)
    {
        switch (day)
        {
            case 1:
                Day1.Solve();
                break;
            case 2:
                Day2.Solve();
                break;
            // Add more cases for each day
            default:
                Console.WriteLine($"Solution for Day {day} is not implemented yet.");
                break;
        }
    }
}
