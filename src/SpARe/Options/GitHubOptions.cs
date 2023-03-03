namespace SpARe.Options;

public class GitHubOptions
{
    public const string Name = "GitHub";

    public required string RepositoryApiUrl { get; init; }
    public required string RepositoryUrl { get; init; }
}
