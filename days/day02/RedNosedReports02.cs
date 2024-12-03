using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class RedNosedReports02
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

        // Separate safe and unsafe reports
        var safeReports = reports.Where(report => Day02InputProcessor.IsSafeReport(report)).ToList();
        var unsafeReports = reports.Where(report => !Day02InputProcessor.IsSafeReport(report)).ToList();

        for (int i = 0; i < unsafeReports.Count; i++)
        {
            var report = unsafeReports[i];
          
            bool canBeMadeSafe = false;

            for (int j = 0; j < report.Count; j++)
            {
                // Create a modified report by removing the number at index j
                var modifiedReport = new List<int>(report);
                modifiedReport.RemoveAt(j);

                if (Day02InputProcessor.IsSafeReport(modifiedReport))
                {
                    canBeMadeSafe = true;
                    safeReports.Add(modifiedReport); 
                    break;
                }
            }
        }

        Console.WriteLine($"\nNumber of safe reports: {safeReports.Count}");
    }
}
