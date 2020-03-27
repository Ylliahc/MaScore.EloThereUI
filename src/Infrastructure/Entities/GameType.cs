using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    /// <summary>
    /// Game type
    /// </summary>
    public class GameType : EntityBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}