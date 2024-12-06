using System.Net;

public static class Day05InputProcessor
{
   public static (int Part1, int Part2) SumMiddlePages(List<string> input)
    {
        var rules = new Dictionary<int, HashSet<int>>();
        var updates = new List<List<int>>();
        bool parsingRules = true;

        // Parse input
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingRules = false;
                continue;
            }

            if (parsingRules)
            {
                var parts = line.Split('|');
                int before = int.Parse(parts[0]);
                int after = int.Parse(parts[1]);
                if (!rules.ContainsKey(before)) rules[before] = new HashSet<int>();
                rules[before].Add(after);
            }
            else
            {
                updates.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }

        int part1Sum = 0;
        int part2Sum = 0;

        foreach (var update in updates)
        {
            if (IsCorrectlyOrdered(update, rules))
            {
                int middleIndex = update.Count / 2;
                part1Sum += update[middleIndex];
                Console.WriteLine($"Correctly ordered update: {string.Join(",", update)}, Middle page: {update[middleIndex]}");
            }
            else 
            {
                var correctedUpdate = CorrectOrder(update, rules);
                int middleIndex = correctedUpdate.Count / 2;
                part2Sum += correctedUpdate[middleIndex];
            }
        }

        return (part1Sum, part2Sum);
    }

    private static bool IsCorrectlyOrdered(List<int> update, Dictionary<int, HashSet<int>> rules)
    {
        for (int i = 0; i < update.Count; i++)
        {
            for (int j = i + 1; j < update.Count; j++)
            {
                if (rules.TryGetValue(update[j], out var afterSet) && afterSet.Contains(update[i]))
                {
                    return false; 
                }
            }
        }
        return true;
    }

    private static List<int> CorrectOrder(List<int> update, Dictionary<int, HashSet<int>> rules)
    {
        return update.OrderBy(x => x)
                     .OrderBy(x => update.Count(y => rules.TryGetValue(x, out var set) && set.Contains(y)))
                     .ToList();
    }

}