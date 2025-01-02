using DataAccessApp.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessApp.Interfaces
{
    public interface IUserDao
    {
        Task<IEnumerable<JudgeModel>> GetAllJudgesAsync();
        Task<IEnumerable<PlayerModel>> GetAllPlayersAsync();
        Task<IEnumerable<OrganizerModel>> GetAllOrganizersAsync();
        Task<IEnumerable<AdminModel>> GetAllAdminsAsync();
    }
}
