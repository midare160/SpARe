using System.Text.Json.Serialization;

namespace Spare.API.Json
{
    public class Repository
    {
        [JsonPropertyName("tag_name")]
        public required string TagName { get; set; }
    }
}
