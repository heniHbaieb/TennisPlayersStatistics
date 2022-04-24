using Contract.DTOs;
using Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerService.AllPlayers();
        }

        [HttpGet("{idPlayer}")]
        public Player GetPlayerById(int idPlayer)
        {
            return _playerService.GetPlayerById(idPlayer);
        }

        [HttpGet]
        public PlayerStats ShowPlayerStats()
        {
            return _playerService.GetPlayerStats();
        }
    }
}
