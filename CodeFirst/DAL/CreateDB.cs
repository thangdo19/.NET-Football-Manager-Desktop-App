using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    class CreateDB : DropCreateDatabaseAlways<FM>
    {
        protected override void Seed(FM context)
        {
            context.Players.Add(new Player { Id_player = "001", Player_name = "Thang", Id_club = 1 });
            context.Players.Add(new Player { Id_player = "002", Player_name = "Tam" , Id_club = 2});
            context.Players.Add(new Player { Id_player = "003", Player_name = "Tu", Id_club = 3 });
            context.Players.Add(new Player { Id_player = "004", Player_name = "Tram", Id_club = 1 });
            context.Players.Add(new Player { Id_player = "005", Player_name = "Nhan", Id_club = 2 });
            context.Players.Add(new Player { Id_player = "006", Player_name = "Hoang", Id_club = 3 });
            context.Players.Add(new Player { Id_player = "007", Player_name = "Van", Id_club = 3 });
            context.Players.Add(new Player { Id_player = "008", Player_name = "Sang", Id_club = 2 });
            context.Players.Add(new Player { Id_player = "009", Player_name = "Tan", Id_club = 1 });
            context.Clubs.Add(new Club { Club_name = "Arsenal" });
            context.Clubs.Add(new Club { Club_name = "Crystal Palace" });
            context.Clubs.Add(new Club { Club_name = "Birmingham City" });
        }
    }
}
