using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterApp.Models
{
 
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public int Age { get; set; }
            

            public int? TeamId { get; set; }
            public Team Team { get; set; }
        }
        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
          

            public ICollection<Player> Players { get; set; }
            public Team()
            {
                Players = new List<Player>();
            }
        }
        public class PlayersListViewModel
        {
            public IEnumerable<Player> Players { get; set; }

            public SelectList Teams { get; set; }

            public SelectList Positions { get; set; }
        }
    }
