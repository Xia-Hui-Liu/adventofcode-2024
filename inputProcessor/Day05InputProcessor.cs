public static class Day05InputProcessor
{
   public static int SumMiddlePages(List<string> input)
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

        int middlePageSum = 0;

        foreach (var update in updates)
        {
            if (IsCorrectlyOrdered(update, rules))
            {
                int middleIndex = update.Count / 2;
                middlePageSum += update[middleIndex];
                Console.WriteLine($"Correctly ordered update: {string.Join(",", update)}, Middle page: {update[middleIndex]}");
            }
        }

        return middlePageSum;
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

}