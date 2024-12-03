public static class Day02InputProcessor
{
    public static bool IsSafeReport(List<int> report)
    {
        if (report.Count < 2)
            return false;
        
        var differences = report.Zip(report.Skip(1), (a, b) => b - a).ToList();

        bool isIncreasing = differences.All(diff => diff >= 1 && diff <= 3);
        bool isDecreasing = differences.All(diff => diff <= -1 && diff >= -3);

        return isIncreasing || isDecreasing;
    }

    
    public static List<List<int>> ParseReports(string rawInput)
    {
        return rawInput.Split('\n')
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Split(' ')
                                        .Where(s => !string.IsNullOrWhiteSpace(s))
                                        .Select(s => 
                                        {
                                            if (int.TryParse(s, out int result))
                                                return result;
                                            throw new FormatException($"Invalid integer format: '{s}'");
                                        })
                                        .ToList())
                    .ToList();
    }

}