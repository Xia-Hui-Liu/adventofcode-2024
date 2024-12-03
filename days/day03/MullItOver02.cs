using System.Text.RegularExpressions;

public static class MullItOver02
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(3);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }
        string mulPattern = @"mul\((\d+),(\d+)\)";
        string controlPattern = @"do\(\)|don't\(\)";

        int sum = 0;
        bool isEnabled = true;

        MatchCollection controlMatches = Regex.Matches(rawInput,$"{controlPattern}|{mulPattern}");

        foreach (Match match in controlMatches)
        {
            if (match.Value == "do()")
            {
                isEnabled = true;
            }
            else if (match.Value == "don't()")
            {
                isEnabled = false;
            }
            else if (Regex.IsMatch(match.Value, mulPattern) && isEnabled)
            {
                Match mulMatch = Regex.Match(match.Value, mulPattern);
                int a = int.Parse(mulMatch.Groups[1].Value);
                int b = int.Parse(mulMatch.Groups[2].Value);
                int product = a * b;
                sum += product;
            }
        }
        Console.WriteLine($"Total mul Sum: {sum}");
    }
}

