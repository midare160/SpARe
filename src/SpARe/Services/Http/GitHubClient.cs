using Spare.API.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SpARe.Services.Http;

public class GitHubClient : IGitHubClient
{
    /// <summary>
    /// Configures the minimum required parameters to access the GitHub-API.
    /// </summary>
    public static HttpClient Configure(HttpClient client, string baseAddress)
    {
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("user-agent", "null");

        return client;
    }

    private readonly HttpClient _httpClient;

    public GitHubClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Repository> GetRepositoryAsync() => 
        await _httpClient.GetFromJsonAsync<Repository>("releases/latest") ?? throw new UnreachableException($"{nameof(Repository)} was null.");
}
