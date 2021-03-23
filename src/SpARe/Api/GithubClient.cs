using Spare.Api.Json;
using Spare.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spare.Api
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
        public async Task<Repository?> GetRepositoryAsync(string repoUrl)
        {
            repoUrl.ThrowIfNullOrEmpty(nameof(repoUrl));

            return await JsonSerializer.DeserializeAsync<Repository>(
                await this.GetStreamAsync(repoUrl), 
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }
        #endregion
    }
}
