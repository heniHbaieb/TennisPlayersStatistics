using Contract.DTOs;
using System.Collections.Generic;

namespace Contract.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> AllPlayers();
        Player GetPlayerById(int idPlayer);
    }
}
