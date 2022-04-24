using Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Test.Repositories
{
    public class PlayerRepositoryTest
    {
        [Fact]
        public void AllPlayers_Test()
        {
            var playerRepository = new PlayerRepository();

            var result = playerRepository.AllPlayers();

            Assert.Equal(5, result.Count());
            Assert.All(result, entity => Assert.NotNull(entity.Data));
            Assert.All(result, entity => Assert.NotNull(entity.Country));
        }

        [Theory]
        [InlineData(52, "Novak", 2)]
        [InlineData(65, "Stan", 21)]
        [InlineData(17, "Rafael", 1)]
        public void GetPlayer_Test(int playerId, string firstName, int rank)
        {
            var playerRepository = new PlayerRepository();

            var result = playerRepository.GetPlayer(playerId);

            Assert.NotNull(result);
            Assert.Equal(firstName, result.Firstname);
            Assert.Equal(rank, result.Data.Rank);
        }
    }
}
