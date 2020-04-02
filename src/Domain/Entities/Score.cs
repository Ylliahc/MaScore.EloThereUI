using System;

namespace MaScore.EloThereUI.Domain.Entities
{
    /// <summary>
    /// Score entity
    /// </summary>
    public class Score : EntityBase
    {
        /// <summary>
        /// Game type concerned by the score
        /// </summary>
        /// <value></value>
        public string GameTypeId { get; set; }
        /// <summary>
        /// Date of the score
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Number games played by player
        /// </summary>
        /// <value></value>
        public int NumberGamesPlayed { get; set; }
        /// <summary>
        /// Number of consecutive wins
        /// </summary>
        /// <value></value>
        public int NumberConsecutiveWins { get; set; }
        /// <summary>
        /// Score value
        /// </summary>
        /// <value></value>
        public int Value { get; set; }
    }
}