namespace MaScore.EloThereUI.Infrastructure.Configurations
{
    public class GameTypeResourceConfiguration : IResourceConfiguration
    {
        public string ResourceName { get; set; }
        public string GetByPlayerIdEndPoint { get; set; }
    }
}