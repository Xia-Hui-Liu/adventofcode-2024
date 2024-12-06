public static class PrintQueue01
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
            int result = Day05InputProcessor.SumMiddlePages(input);
            Console.WriteLine($"Sum of middle page numbers from correctly ordered updates: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

