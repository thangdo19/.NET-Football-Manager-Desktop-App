using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    [Table("Player")]
    public class Player
    {
        private string _id_player;
        private string _player_name;
        private int _id_club;
        private Club _Club;

        [Key]
        public string Id_player { get => _id_player; set => _id_player = value; }
        public string Player_name { get => _player_name; set => _player_name = value; }
        public int Id_club { get => _id_club; set => _id_club = value; }
        [ForeignKey("Id_club")]
        public virtual Club Club { get => _Club; set => _Club = value; }
    }
}
