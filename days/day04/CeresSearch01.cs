using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class CeresSearch01
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(4);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        string word = "XMAS";

        List<string> matrix = Day04InputProcessor.ParseInputToMatrix(rawInput);

        int occurrences = Day04InputProcessor.CountWordOccurrences(word, matrix);

       Console.WriteLine($"The word '{word}' occurs {occurrences} times in the grid.");
    }

   
  
}
