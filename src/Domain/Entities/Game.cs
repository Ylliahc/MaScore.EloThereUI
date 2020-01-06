using System;

namespace MaScore.EloThereUI.Domain.Entities
{
    public class Game : EntityBase
    {
        public string TypeId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public string Winner { get; set; }
        public DateTime GameDate { get; set; }
    }
}