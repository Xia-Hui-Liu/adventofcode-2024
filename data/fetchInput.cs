public static class FetchInput
{
    private static readonly string _sessionCookie = Environment.GetEnvironmentVariable("AOC_SESSION") ?? string.Empty;
    public static string SessionCookie => _sessionCookie;

    public static async Task<string> FetchRawInput(int day)
    {
        if (string.IsNullOrEmpty(SessionCookie))
        {
            throw new InvalidOperationException("Session cookie is not set in the environment variables.");
        }

        string url = $"https://adventofcode.com/2024/day/{day}/input";
        using HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Add("Cookie", $"session={SessionCookie}");
        client.DefaultRequestHeaders.Add("User-Agent", "Advent of Code Input Fetcher - C# Script");

        try
        {
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching input: {ex.Message}");
            return string.Empty;
        }
    }
}