
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Models;

namespace UserDaoLib.Daos.Interfaces
{
    public interface IUserDao
    {
        Task<int>CreateWhitHashedPasswordAsync(UserModel user);
        Task<UserModel> GetUserWhitTokenAsync(int id);
        Task<UserModel> LogInAsync(string nombre);
    }
}
