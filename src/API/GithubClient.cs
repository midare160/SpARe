using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAdRemover.API.Json;

namespace SpotifyAdRemover.API
{
    public class GithubClient : HttpClient
    {
        #region Constructors
        public GithubClient(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent))
            {
                userAgent = Application.ProductName;
            }

            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            DefaultRequestHeaders.Add("user-agent", userAgent);
        }
        #endregion

        #region Async Methods
        public async Task<Repository> GetRepositoryAsync(string repoUrl)
        {
            if (string.IsNullOrEmpty(repoUrl))
            {
                throw new ArgumentNullException(nameof(repoUrl));
            }

            return await JsonSerializer.DeserializeAsync<Repository>(await this.GetStreamAsync(repoUrl));
        }
        #endregion
    }
}
