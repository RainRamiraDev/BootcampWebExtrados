using RefreshTokenApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserDaoLib.Daos.Interfaces
{
    public interface IRefreshTokenDao
    {

        Task<bool> VerifyTokenAsync(Guid token);
        Task<int> DeleteRefreshTokenAsync(Guid token);
        Task<int> SaveRefreshTokenAsync(Guid token, int userId, DateTime expirationDate);

        Task<Guid> GetRefreshTokenAsync(int userId);
    }
}
