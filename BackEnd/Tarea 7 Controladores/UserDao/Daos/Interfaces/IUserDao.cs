
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
        Task<int> CreateAsync(UserModel user);
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> GetByEmailAsync(string email);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<bool> UpdateAsync(UserModel user);
        Task<bool> DeleteAsync(int id);
    }
}
