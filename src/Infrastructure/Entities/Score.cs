using System;
using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    /// <summary>
    /// Score entity
    /// </summary>
    public class Score : EntityBase
    {
        /// <summary>
        /// Player
        /// </summary>
        /// <value></value>
        [JsonProperty("player")]
        public PlayerBase Player { get; set; }
        /// <summary>
        /// Game type id
        /// </summary>
        /// <value></value>
        [JsonProperty("gameTypeId")]
        public string GameTypeId { get; set; }
        /// <summary>
        /// Date of the score
        /// </summary>
        /// <value></value>
        [JsonProperty("scoreDate")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Number games played by player
        /// </summary>
        /// <value></value>
        [JsonProperty("numberOfGamesPlayed  ")]
        public int NumberGamesPlayed { get; set; }
        /// <summary>
        /// Number of consecutive wins
        /// </summary>
        /// <value></value>
        [JsonProperty("numberOfConsecutiveWins")]
        public int NumberConsecutiveWins { get; set; }
        /// <summary>
        /// Score value
        /// </summary>
        /// <value></value>
        [JsonProperty("scoreValue")]
        public int Value { get; set; }
    }    
}