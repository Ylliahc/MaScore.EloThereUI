using System;

namespace WebApp.ViewModels
{
    /// <summary>
    /// Player statistics view model
    /// </summary>
    public class PlayerStatisticsViewModel
    {
        /// <summary>
        /// First game date played
        /// </summary>
        /// <value></value>
        public DateTime FirstGameDate {get;set;}
        /// <summary>
        /// Last game date played
        /// </summary>
        /// <value></value>
        public DateTime LastGameDate { get; set; }
        /// <summary>
        /// Total number  of game played
        /// </summary>
        /// <value></value>
        public int NumberGamesPlayed { get; set; }
        /// <summary>
        /// How many game type played
        /// </summary>
        /// <value></value>
        public int NumberGameTypes { get; set; }
        /// <summary>
        /// Total points, all games
        /// </summary>
        /// <value></value>
        public int TotalPoints { get; set; }
    }
}