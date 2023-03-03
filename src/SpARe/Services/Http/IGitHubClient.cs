using Spare.API.Json;

namespace SpARe.Services.Http;

public interface IGitHubClient
{
    Task<Repository> GetRepositoryAsync();
}
