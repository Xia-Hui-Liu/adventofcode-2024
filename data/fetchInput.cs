using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public static class FetchInput
{
    private static readonly string _sessionCookie = Environment.GetEnvironmentVariable("AOC_SESSION") ?? string.Empty;
    public static string SessionCookie => _sessionCookie;

    public static async Task<(List<string> LeftArray, List<string> RightArray)> FetchAndProcessInput(int day)
    {
        if (string.IsNullOrEmpty(SessionCookie))
        {
            Console.Error.WriteLine("Session cookie is not set in the environment variables.");
            Environment.Exit(1);
        }

        string url = $"https://adventofcode.com/2024/day/{day}/input";
        using HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Add("Cookie", $"session={SessionCookie}");
        client.DefaultRequestHeaders.Add("User-Agent", "Advent of Code Input Fetcher - C# Script");

        try
        {
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using Stream responseStream = await response.Content.ReadAsStreamAsync();
            var (leftArray, rightArray) = await ProcessInputStream(responseStream);
            return (leftArray, rightArray);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching input: {ex.Message}");
            return (new List<string>(), new List<string>());
        }
    }

    public static async Task<(List<string> LeftArray, List<string> RightArray)> ProcessInputStream(Stream inputStream)
    {
        using StreamReader reader = new StreamReader(inputStream);

        var leftArray = new List<string>();
        var rightArray = new List<string>();

        while (!reader.EndOfStream)
        {
            string line = await reader.ReadLineAsync();
            
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

        // Sort the left and right arrays
        leftArray.Sort();
        rightArray.Sort();

        return (leftArray, rightArray);
    }
}