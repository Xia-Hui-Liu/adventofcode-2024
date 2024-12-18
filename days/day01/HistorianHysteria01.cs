public static class HistorianHysteria01
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(1);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        var (leftArray, rightArray) = Day01InputProcessor.ProcessInputSort(rawInput);

        if (leftArray.Count == 0 || rightArray.Count == 0 || leftArray.Count != rightArray.Count)
        {
            Console.WriteLine("Invalid input: Arrays are empty or have different lengths.");
            return;
        }

        Console.WriteLine("Processing Day 1 logic...");

        int sum = Day01InputProcessor.SumDifference(leftArray, rightArray);
        
        Console.WriteLine($"Sum of positive differences: {sum}");
    }
}