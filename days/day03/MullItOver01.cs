using System.Text.RegularExpressions;

public static class MullItOver01
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(3);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }
        string pattern = @"mul\((\d+),(\d+)\)";

        int sum = 0;

        foreach (Match match in Regex.Matches(rawInput, pattern))
        {
            if (match.Groups.Count == 3 &&
                !string.IsNullOrEmpty(match.Groups[1].Value) &&
                !string.IsNullOrEmpty(match.Groups[2].Value))
            {
                int a = int.Parse(match.Groups[1].Value);
                int b = int.Parse(match.Groups[2].Value);
                int product = a * b;
                sum += product;
            }
        }
        Console.WriteLine($"Total Sum: {sum}");
    }
}

