using System;

namespace MaScore.EloThereUI.Infrastructure.Entities
{
    public class Score : EntityBase
    {
        public PlayerBase Player { get; set; }
        public string GameTypeId { get; set; }
        public DateTime Date { get; set; }
        public int NumberGamesPlayed { get; set; }
        public int NumberConsecutiveWins { get; set; }
    }    
}