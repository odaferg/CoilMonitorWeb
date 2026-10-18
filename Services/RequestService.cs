using CoilMonitorWeb.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

public class RequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateRequest(CommandRequest request)
    {
        // Read requests.json
        string RequestsUrl =
        $"https://gist.githubusercontent.com/odaferg/632d5e2a1f95e88e6d8d1bb42ddaca5d/raw/requests.json?v={DateTime.UtcNow.Ticks}";
        var json = await _httpClient.GetStringAsync(RequestsUrl);

        var requests =
            JsonSerializer.Deserialize<List<CommandRequest>>(json)
            ?? new List<CommandRequest>();

        // Add request
        requests.Add(request);

        // Save requests.json
        await SaveRequests(requests);
    }

    public async Task SaveRequests(
    List<CommandRequest> requests)
    {
        const string gistId = "632d5e2a1f95e88e6d8d1bb42ddaca5d";
        const string githubToken = "";

        var json = JsonSerializer.Serialize(
            requests,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        // PATCH the gist using GitHub API
        var body = new
        {
            files = new Dictionary<string, object>
            {
                ["requests.json"] = new
                {
                    content = json
                }
            }
        };

        string bodyJson =
        JsonSerializer.Serialize(body);

        using var client = new HttpClient();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                githubToken);

        client.DefaultRequestHeaders.UserAgent.ParseAdd(
            "CoilMonitor");

        var content = new StringContent(
            bodyJson,
            Encoding.UTF8,
            "application/json");

        var response =
            await client.PatchAsync(
                $"https://api.github.com/gists/{gistId}",
                content);

        response.EnsureSuccessStatusCode();
    }
}