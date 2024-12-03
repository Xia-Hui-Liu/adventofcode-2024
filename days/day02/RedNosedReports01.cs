using System.Linq;

public static class RedNosedReports01
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(2);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        var reports = Day02InputProcessor.ParseReports(rawInput);

        var safeReports = reports.Where(Day02InputProcessor.IsSafeReport).ToList();

        foreach (var report in reports)
        {
            var status = Day02InputProcessor.IsSafeReport(report) ? "Safe" : "Unsafe";
            // Console.WriteLine($"{string.Join(" ", report)}: {status}");
        }
        Console.WriteLine($"\nNumber of safe reports: {safeReports.Count}");
    }
    
}