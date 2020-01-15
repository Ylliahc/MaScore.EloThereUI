namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    public class PlayerResourceConfiguration
    {
        public string ResourceName { get; set; } 
        public string GetByIdEndpoint { get; set; }
        public string DeleteEndpoint { get; set; }
        public string GetByGameTypeIdEndpoint { get; set; }
        public string GetAllEndPoint { get; set; }
        public string PostPlayerEndpoint { get; set; }
        public string AddGameTypeEndpoint { get; set; }
        public string RemoveGameTypeEndpoint { get; set; }
    }
}