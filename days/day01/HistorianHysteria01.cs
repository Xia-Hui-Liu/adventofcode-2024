public static class HistorianHysteria01
{
    public static async Task Solve()
    {
        var (leftArray, rightArray) = await FetchInput.FetchAndProcessInput(1);
        
        if (leftArray.Count == 0 || rightArray.Count == 0 || leftArray.Count != rightArray.Count)
        {
            Console.WriteLine("Invalid input: Arrays are empty or have different lengths.");
            return;
        }
        int sum = 0;
        for (int i = 0; i < leftArray.Count; i++)
        {
            if (int.TryParse(leftArray[i], out int leftNum) && int.TryParse(rightArray[i], out int rightNum))
            {
                int difference = rightNum - leftNum;
                sum += Math.Abs(difference); 
            }
            else
            {
                Console.WriteLine($"Warning: Could not parse values at index {i}");
            }
        }

        Console.WriteLine($"Sum of positive differences: {sum}");
    }
}