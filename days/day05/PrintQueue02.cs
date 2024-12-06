public static class PrintQueue02
{
   public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(5);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        try
        {
            List<string> input = rawInput.Split('\n').Select(line => line.Trim()).ToList();
            var (_, part2Sum) = Day05InputProcessor.SumMiddlePages(input);
            Console.WriteLine($"Sum of middle page numbers from corrected updates: {part2Sum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    
    }
}

