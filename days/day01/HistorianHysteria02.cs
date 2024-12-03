public static class HistorianHysteria02
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(1);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        var (leftArray, rightArray) = Day01InputProcessor.ProcessInput(rawInput);

        if (leftArray.Count == 0 || rightArray.Count == 0 || leftArray.Count != rightArray.Count)
        {
            Console.WriteLine("Invalid input: Arrays are empty or have different lengths.");
            return;
        }

        Console.WriteLine("Processing Day 1 part 2 logic...");

        int similarityScore = Day01InputProcessor.CalculateSimilarityScore(leftArray, rightArray);
        
        Console.WriteLine($"Similarity Score: {similarityScore}");
    }
}