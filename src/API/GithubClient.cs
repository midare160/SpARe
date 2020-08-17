using SpotifyAdRemover.API.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyAdRemover.API
{
    public class GithubClient : HttpClient
    {
        #region Constructors
        public GithubClient(string userAgent)
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            DefaultRequestHeaders.Add("user-agent", userAgent);
        }
        #endregion

        #region Methods
        public async Task<Repository> GetRepositoryAsync(string repoUrl)
        {
            return await JsonSerializer.DeserializeAsync<Repository>(await GetStreamAsync(repoUrl));
        }
        #endregion
    }
}
