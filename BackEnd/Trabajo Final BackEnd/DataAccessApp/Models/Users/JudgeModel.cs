using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessApp.Models.Player
{
    public class JudgeModel
    {
        public int IdJudge { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string AvatarUrl { get; set; }
    }
}
