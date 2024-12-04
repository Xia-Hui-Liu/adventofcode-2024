using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class CeresSearch02
{
    public static async Task Solution()
    {
        string rawInput = await FetchInput.FetchRawInput(4);

        if (string.IsNullOrEmpty(rawInput))
        {
            Console.WriteLine("Failed to fetch input.");
            return;
        }

        List<string> matrix = Day04InputProcessor.ParseInputToMatrix(rawInput);

        int occurrences = Day04InputProcessor.CountXMASPatterns(matrix);

       Console.WriteLine($"The word 'X-MAS' occurs {occurrences} times in the grid.");
    }

   
  
}
