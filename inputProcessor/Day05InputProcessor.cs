public static class Day05InputProcessor
{
    public static (List<string> UpList, List<string> DownList) ProcessInput(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        List<string> UpList = new List<string>();
        List<string> DownList = new List<string>();

        foreach (var line in lines)
        {
            if (line.Contains("|"))
            {
                UpList.Add(line);
            }
            else if (line.Contains(","))
            {
                DownList.Add(line);
            }
        }
        return (UpList, DownList);
    }
}