namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    /// <summary>
    /// Global configuration for MaScore client API
    /// </summary>
    public class MaScoreClientConfiguration
    {
        public string Url { get; set; }
        /// <summary>
        /// Configuration for game type resource
        /// </summary>
        /// <value></value>
        public GameTypeResourceConfiguration GameTypeResourceConfiguration {get;set;}
        /// <summary>
        /// Configuration for player resource
        /// </summary>
        /// <value></value>
        public PlayerResourceConfiguration PlayerResourceConfiguration {get;set;}
        /// <summary>
        /// Configuration for score resource
        /// </summary>
        /// <value></value>
        public ScoreResourceConfiguration ScoreResourceConfiguration {get;set;}
    }
}