using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FilterApp.Models;
using static FilterApp.Models.Player;

namespace FilterApp.Models
{
    public class SoccerContext : DbContext 
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }

    public class SoccerDbInitializer : DropCreateDatabaseAlways<SoccerContext>
    {
        protected override void Seed(SoccerContext db)
        {
            Team t1 = new Team { Name = "Barsa" };
            Team t2 = new Team { Name = "Real" };
            db.Teams.Add(t1);
            db.Teams.Add(t2);
            db.SaveChanges();

            Player pl1 = new Player { Name = "Ronaldy", Age = 31, Position = "Forvard", Team = t2 };
            Player pl2 = new Player { Name = "Messi", Age = 28, Position = "Forvard", Team = t1 };
            Player pl3 = new Player { Name = "Khavi", Age = 34, Position = "povForvard", Team = t1 };
            Player pl4 = new Player { Name = "Bayl", Age = 25, Position = "povForvard", Team = t2 };
            Player pl5 = new Player { Name = "Nayman", Age = 22, Position = "Forvard", Team = t1 };
            Player pl6 = new Player { Name = "Rodriges", Age = 26, Position = "povForvard", Team = t2 };

            db.Players.AddRange(new List<Player> { pl1, pl2, pl3, pl4, pl5, pl6 });
            db.SaveChanges();
        }
    }
}