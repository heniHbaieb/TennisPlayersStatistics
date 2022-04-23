using AutoMapper;
using Contract.DTOs;
using Contract.Services;
using Domain.Repositories;
using System.Collections.Generic;

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
            return _mapper.Map<IEnumerable<Player>>(players);
        }
    }
}
