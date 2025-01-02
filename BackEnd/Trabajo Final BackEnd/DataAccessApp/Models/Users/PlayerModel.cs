using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace DataAccessApp.Models.Player
{
    public class PlayerModel
    {
        public int Id_user { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Alias { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TournamentsWon { get; set; }
        public int Disqualifications { get; set; }
        public string DiscualificationsReasons { get; set; }
        public string AvatarUrl { get; set; }
    }
}
