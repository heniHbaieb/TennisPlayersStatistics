using AutoMapper;
using Contract.DTOs;
using Contract.Services;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Player> AllPlayers()
        {
            var players = _playerRepository.AllPlayers();
            players = players.OrderBy(p => p.Data.Rank).ToList();
            return _mapper.Map<IEnumerable<Player>>(players);
        }

        public Player GetPlayerById(int idPlayer)
        {
            var player = _playerRepository.GetPlayer(idPlayer);
            return _mapper.Map<Player>(player);
        }

        public PlayerStats GetPlayerStats()
        {
            var players = _playerRepository.AllPlayers();
            return new PlayerStats()
            {
                MedianHeight = players.Average(p => p.Data.Height),
                Imc = players.Average(p => (((double)p.Data.Weight / 1000) / (((double)p.Data.Height / 100) * ((double)p.Data.Height / 100)))),
                Country = players.Where(p => p.Data.Points == players.Max(p => p.Data.Points)).Select(p => p.Country.Code).FirstOrDefault()
            };
        }
    }
}
