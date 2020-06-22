using CodeFirst.DAL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.BLL
{
    class PlayerHandler
    {
        private static PlayerHandler _Instance;
        public static PlayerHandler Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new PlayerHandler();
                return _Instance;
            }
            private set => _Instance = value;
        }

        public delegate List<Player> Sorting(List<Player> players);

        private PlayerHandler() { }

        public List<Player> GetListPlayers()
        {
            try
            {
                return FM.Instance.Players.Select(player => player).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeletePlayers(List<string> listId)
        {
            try
            {
                foreach (string id in listId)
                {
                    var player = FM.Instance.Players
                        .Where(p => p.Id_player == id)
                        .FirstOrDefault();
                    FM.Instance.Players.Remove(player);
                    FM.Instance.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditPlayer(Player player)
        {
            try
            {
                var updatePlayer = FM.Instance.Players.Where(p => p.Id_player == player.Id_player).FirstOrDefault();
                updatePlayer.Player_name = player.Player_name;
                updatePlayer.Id_club = player.Id_club;
                FM.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Player> SearchPlayers(string player_name, Club club)
        {
            if (player_name.Length == 0)
                return FM.Instance.Players.Where(player => player.Id_club == club.Id_club).ToList();
            else
                return FM.Instance.Players
                    .Where(player =>
                        (player.Player_name.ToLower().Contains(player_name.ToLower())
                            && (player.Id_club == club.Id_club)))
                    .ToList();
        }

        public List<Player> SortByName(List<Player> data)
        {
            if (data == null) return data;
            List<Player> players = new List<Player>(data);
            if (players.Count > 0)
            {
                players.Sort((player1, player2) =>
                {
                    return player1.Player_name.CompareTo(player2.Player_name);
                });
            }
            return players;
        }

        public List<Player> SortListPlayers(List<Player> data, Sorting sort)
        {
            return sort(data);
        }

        public bool AddPlayer(Player player)
        {
            try
            {
                FM.Instance.Players.Add(player);
                FM.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
