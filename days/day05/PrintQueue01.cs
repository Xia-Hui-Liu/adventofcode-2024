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

        var (UpList, DownList) = Day05InputProcessor.ProcessInput(rawInput);
    }
}