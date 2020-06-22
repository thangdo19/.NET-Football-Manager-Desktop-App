using CodeFirst.DAL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.BLL
{
    class ClubHandler
    {
        private static ClubHandler _Instance;
        public static ClubHandler Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ClubHandler();
                return _Instance;
            }
            private set => _Instance = value;
        }

        private ClubHandler() { }

        public List<Club> GetListClub()
        {
            try
            {
                return FM.Instance.Clubs.Select(club => club).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Club GetClub(int Id_club)
        {
            try
            {
                return FM.Instance.Clubs
                    .Where(club => club.Id_club == Id_club)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
