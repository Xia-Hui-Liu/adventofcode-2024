using System.Data;

public static class Day04InputProcessor
{
    private static readonly int[,] Directions = {
            {-1, -1}, {-1, 0}, {-1, 1},
            { 0, -1},         { 0, 1},
            { 1, -1}, { 1, 0}, { 1, 1}
        };
    
    public static int CountWordOccurrences(string word, List<string> grid)
    {
        int wordLength = word.Length;
        int rows = grid.Count;
        int cols = grid[0].Length;
        int count = 0;

        // Loop through each position in the grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Check if the word starts at this position in any direction
                foreach (var (dx, dy) in GetDirections())
                {
                    if (IsWordAtPosition(word, row, col, dx, dy, grid))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
            
    private static bool IsWordAtPosition(string word, int row, int col, int dx, int dy, List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;

        for (int i = 0; i < word.Length; i++)
        {
            int newRow = row + i * dy;
            int newCol = col + i * dx;

            // Check if out of bounds or character mismatch
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow][newCol] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<(int dx, int dy)> GetDirections()
    {
        for (int i = 0; i < Directions.GetLength(0); i++)
        {
            yield return (Directions[i, 0], Directions[i, 1]);
        }
    }

    public static List<string> ParseInputToMatrix(string input)
    {
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        return new List<string>(rows);
    }
}


