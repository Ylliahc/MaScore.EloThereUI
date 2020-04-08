using MaScore.EloThereUI.Domain.Repositories;
using Moq;

namespace MaScore.EloThereUI.Application.UnitTests.Services
{
    /// <summary>
    /// Contains all mock preparation for services tests
    /// </summary>
    public class ServiceTestsBase
    {
        public IScoreRepository GetScoreRepository()
        {
            var repositoryMock = new Mock<IScoreRepository>();

            repositoryMock.Setup(
                x => x.GetHistory(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>()))
                .ReturnsAsync(new System.Collections.Generic.List<Domain.Entities.Score>());

            return repositoryMock.Object;
        }
    }
}