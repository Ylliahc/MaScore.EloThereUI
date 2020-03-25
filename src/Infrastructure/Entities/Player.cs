using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    public class PlayerBase : EntityBase
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}