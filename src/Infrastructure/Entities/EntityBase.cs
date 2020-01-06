using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    public class EntityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}