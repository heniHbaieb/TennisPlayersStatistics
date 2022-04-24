using Application.Services;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Test.Services
{
    public class PlayerServiceTest
    {
        [Fact]
        public void AllPlayers_Test()
        {
            var playerRepository = new Mock<IPlayerRepository>();
            var mapper = new Mock<IMapper>();
            var players = new List<Player>
            {
                new Player(){Id=1,Data = new Data(){Rank=10}},
                new Player(){Id=6,Data = new Data(){Rank=2}},
                new Player(){Id=18,Data = new Data(){Rank=15}},
                new Player(){Id=7,Data = new Data(){Rank=7}},
            };

            var playersDTO = new List<Contract.DTOs.Player>
            {
                new Contract.DTOs.Player(){Id=1,Data = new Contract.DTOs.Data(){Rank=10}},
                new Contract.DTOs.Player(){Id=6,Data = new Contract.DTOs.Data(){Rank=2}},
                new Contract.DTOs.Player(){Id=18,Data = new Contract.DTOs.Data(){Rank=15}},
                new Contract.DTOs.Player(){Id=7,Data = new Contract.DTOs.Data(){Rank=7}},
            };

            playerRepository
                .Setup(r => r.AllPlayers())
                .Returns(players);
            mapper
                .Setup(m => m.Map<IEnumerable<Contract.DTOs.Player>>(It.IsAny<List<Player>>()))
                .Returns(playersDTO.OrderBy(p => p.Data.Rank));

            var playerService = new PlayerService(playerRepository.Object, mapper.Object);
            var result = playerService.AllPlayers();

            Assert.Equal(4, result.Count());
            Assert.Equal(players.OrderBy(p => p.Data.Rank).Select(p => p.Id), result.Select(p => p.Id));
        }

        [Fact]
        public void GetPlayerStats_Test()
        {
            var playerRepository = new Mock<IPlayerRepository>();
            var mapper = new Mock<IMapper>();
            var players = new List<Player>
            {
                new Player(){Id=1,Data = new Data(){Height= 180,Weight=85000,Points=35487}, Country=new Country(){Code="USA"} },
                new Player(){Id=1,Data = new Data(){Height= 170,Weight=82000,Points=15486}, Country=new Country(){Code="TN"} },
                new Player(){Id=1,Data = new Data(){Height= 190,Weight=93000,Points=25483}, Country=new Country(){Code="FR"} },
                new Player(){Id=1,Data = new Data(){Height= 165,Weight=74000,Points=27956}, Country=new Country(){Code="ESP"} },
            };

            playerRepository
                .Setup(r => r.AllPlayers())
                .Returns(players);

            var playerService = new PlayerService(playerRepository.Object, mapper.Object);
            var result = playerService.GetPlayerStats();

            Assert.NotNull(result);
            Assert.Equal("USA", result.Country);
            Assert.Equal(26.887735771184534, result.Imc);
            Assert.Equal(176.25, result.MedianHeight);
        }
    }
}
