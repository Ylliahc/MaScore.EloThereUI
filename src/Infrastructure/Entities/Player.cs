using System.Collections.Generic;
using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    /// <summary>
    /// Player entity received from api
    /// </summary>
    public class Player : PlayerBase
    {
        /// <summary>
        /// Game types player played
        /// </summary>
        /// <value></value>
        [JsonProperty("gameTypes")]
        public List<GameType> GameTypes {get;set;}
    }
}