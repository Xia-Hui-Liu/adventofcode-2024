public static class Day01InputProcessor
{
    public static (List<string> LeftArray, List<string> RightArray) ProcessInputSort(string input)
    {
        var (leftArray, rightArray) = ProcessInput(input);

        leftArray.Sort();
        rightArray.Sort();

        return (leftArray, rightArray);
    }

     public static (List<string> LeftArray, List<string> RightArray) ProcessInput(string input)
    {
        var leftArray = new List<string>();
        var rightArray = new List<string>();

        using (StringReader reader = new StringReader(input))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                   
                    if (parts.Length == 2)
                    {
                        leftArray.Add(parts[0].Trim());
                        rightArray.Add(parts[1].Trim());
                    }
                    else
                    {
                        Console.WriteLine("Line does not contain exactly two parts or contains empty values.");
                    }
                }
            }
        }

        return (leftArray, rightArray);
    }

    public static int SumDifference(List<string> leftArray, List<string> rightArray)
    {
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
        return sum;
    }
    public static int CalculateSimilarityScore(List<string> leftArray, List<string> rightArray)
    {
        int similarityScore = 0;

        foreach (var leftNumber in leftArray)
        {
            if (int.TryParse(leftNumber, out int number))
            {
                int occurrences = rightArray.Count(x => x == leftNumber);
                similarityScore += number * occurrences;
            }
            else
            {
                Console.WriteLine($"Warning: Could not parse '{leftNumber}' as an integer.");
            }
        }
        return similarityScore;
    }


}