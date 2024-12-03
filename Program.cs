using dotenv.net;

DotEnv.Load();
Console.WriteLine("Advent of Code 2024");
Console.WriteLine("Enter the day to solve (1-25):");
string input = Console.ReadLine()!;

if (int.TryParse(input, out int day) && day >= 1 && day <= 25)
{
    await SolutionDay(day);
}
else
{
    Console.WriteLine("Invalid day. Please enter a number between 1 and 25.");
}

async Task SolutionDay(int day)
{
    switch (day)
    {
        case 1:
            await HistorianHysteria01.Solution();
            await HistorianHysteria02.Solution();
            break;
        case 2:
            await RedNosedReports01.Solution();
            break;
        // Add more cases for each day
        default:
            Console.WriteLine($"Solution for Day {day} is not implemented yet.");
            break;
    }
}