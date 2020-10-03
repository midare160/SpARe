using Spare.API.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spare.API
{
    public class GithubClient : HttpClient
    {
        #region Constructors
        public GithubClient(string userAgent)
        {
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            this.DefaultRequestHeaders.Add("user-agent", userAgent);
        }
        #endregion

        #region Methods
        public async Task<Repository> GetRepositoryAsync(string repoUrl) 
            => await JsonSerializer.DeserializeAsync<Repository>(await this.GetStreamAsync(repoUrl));
        #endregion
    }
}
