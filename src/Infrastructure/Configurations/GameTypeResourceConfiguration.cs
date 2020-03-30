namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for gametype resource
    /// </summary>
    public class GameTypeResourceConfiguration : IResourceConfiguration
    {
        public string ResourceName { get; set; }
        /// <summary>
        /// Endpoint to get players' gametypes
        /// </summary>
        /// <value></value>
        public string GetByPlayerIdEndPoint { get; set; }
    }
}