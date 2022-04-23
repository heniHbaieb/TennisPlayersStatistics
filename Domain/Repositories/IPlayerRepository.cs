using Domain.Models;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> AllPlayers();
        Player GetPlayer(int idPlayer);
    }
}
