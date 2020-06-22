using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    [Table("Club")]
    public class Club
    {
        private int _id_club;
        private string _club_name;
        private ICollection<Player> _Players;

        [Key]
        public int Id_club { get => _id_club; set => _id_club = value; }
        public string Club_name { get => _club_name; set => _club_name = value; }
        public virtual ICollection<Player> Players { get => _Players; set => _Players = value; }

        public Club()
        {
            Players = new HashSet<Player>();
        }

        public override string ToString()
        {
            return Club_name;
        }

        public override bool Equals(object obj)
        {
            try
            {
                var club = (Club)obj;
                return this.Id_club == club.Id_club;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Id_club.GetHashCode();
        }
    }
}
