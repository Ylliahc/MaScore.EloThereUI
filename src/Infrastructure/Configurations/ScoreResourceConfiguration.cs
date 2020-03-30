namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for Score resource
    /// </summary>
    public class ScoreResourceConfiguration : IResourceConfiguration
    {
        public string ResourceName { get; set;}
        /// <summary>
        /// Endpoint to get score history for a player gametype couple
        /// </summary>
        /// <value></value>
        public string HistoryEndpoint {get;set;}
    }
}