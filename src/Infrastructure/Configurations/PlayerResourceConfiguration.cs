namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    public class PlayerResourceConfiguration : IResourceConfiguration
    {
        public string ResourceName { get; set; } 
        public string GetByGameTypeIdEndpoint { get; set; }
        public string PutAddGameTypeEndpoint { get; set; }
        public string PutRemoveGameTypeEndpoint { get; set; }
    }
}