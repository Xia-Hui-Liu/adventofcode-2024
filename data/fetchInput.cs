using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class FetchInput {
    private static readonly string SessionCookie = Environment.GetEnvironmentVariable("AOC_SESSION");

    public static async Task Main(string[] args) 
    {
        if (string.IsNullOrEmpty(SessionCookie))
        {
            Console.Error.WriteLine("Session cookie is not set in the environment variables.");
            Environment.Exit(1);
        }

        if (args.Length == 0 || !int.TryParse(args[0], out int day) || day < 1 || day > 25)
        {
            Console.Error.WriteLine("Please provide a valid day (1-25) as a command-line argument.");
            Environment.Exit(1);
        }

        await FetchAndProcessInput(day);
    }

    private static async Task FetchAndProcessInput(int day)
    {
        string url = $"https://adventofcode.com/2023/day/{day}/input";
        using HttpClient client= new HttpClient();

        // Set up headers
        client.DefaultRequestHeaders.Add("Cookie", $"session={SessionCookie}");
        client.DefaultRequestHeaders.Add("User-Agent", "Advent of Code Input Fetcher - C# Script");

        try 
        {
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            // Get the response stream
            using Stream responseStream = await response.Content.ReadAsStreamAsync();
            using StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

            const int ChunkSize = 100; // Lines per chunk
            var buffer = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLineAsync();
                if (line != null)
                {
                    buffer.Add(line);
                }

                if (buffer.Count >= ChunkSize)
                {
                    ProcessChunk(buffer);
                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
            {
                ProcessChunk(buffer);
            }
            Console.WriteLine("Input processing completed.");
        } 
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching input: {ex.Message}");
        }
    }

    private static void ProcessChunk(List<string> chunk)
    {
        // Process the chunk of data
        
    }
}