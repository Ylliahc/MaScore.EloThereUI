using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    /// <summary>
    /// Base for entities
    /// </summary>
    public class EntityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}