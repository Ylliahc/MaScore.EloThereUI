using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    public class GameType : EntityBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}