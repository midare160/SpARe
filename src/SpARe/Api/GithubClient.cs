using Newtonsoft.Json;
using Spare.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Spare.Api
{
    public class GithubClient : HttpClient
    {
        #region Constructors
        public GithubClient()
        {
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            this.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("request"));
        }
        #endregion

        #region Methods
        public async Task<string?> GetRepositoryTagNameAsync(string repoUrl)
        {
            repoUrl.ThrowIfNullOrEmpty(nameof(repoUrl));

            var responseText = await this.GetStringAsync(repoUrl);
            dynamic? response = JsonConvert.DeserializeObject(responseText);

            return response?.tag_name;
        }
        #endregion
    }
}
