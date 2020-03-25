namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for player resource
    /// </summary>
    public class PlayerResourceConfiguration : IResourceConfiguration
    {
        public string ResourceName { get; set; }
        /// <summary>
        /// Endpoint to get players by a game type id
        /// </summary>
        /// <value></value>
        public string GetByGameTypeIdEndpoint { get; set; }
        /// <summary>
        /// Add a gametype to a player
        /// </summary>
        /// <value></value>
        public string PutAddGameTypeEndpoint { get; set; }
        /// <summary>
        /// Remove a gametype from a player
        /// </summary>
        /// <value></value>
        public string PutRemoveGameTypeEndpoint { get; set; }
    }
}