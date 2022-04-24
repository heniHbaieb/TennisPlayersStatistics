using Domain.Models;
using Domain.Repositories;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IEnumerable<Player> ImportFromStorage()
        {
            string path = $"C:\\Users\\hhbaieb\\Documents\\Perso\\TennisPlayersStatistics\\Domain\\Storage\\Players.json";
            JObject data = JObject.Parse(File.ReadAllText(path));
            return data["players"].ToObject<IEnumerable<Player>>();
        }

        public IEnumerable<Player> AllPlayers()
        {
            var players = ImportFromStorage();
            return players;
        }

        public Player GetPlayer(int idPlayer)
        {
            var players = ImportFromStorage();
            return players.FirstOrDefault(p => p.Id == idPlayer);
        }
    }
}
