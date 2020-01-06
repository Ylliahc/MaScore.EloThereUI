using System.Collections.Generic;

namespace MaScore.EloThereUI.Domain.Entities
{
    public class Player : EntityBase
    {
        /// <summary>
        /// Player's firstname
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }
        /// <summary>
        /// Player's lastname
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }
        /// <summary>
        /// GameTypes player plays
        /// </summary>
        /// <value></value>
        public List<GameType> GameTypes { get; set; }
    }
}