using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshTokenApp.Service.Interface
{
    public interface IRefreshTokenService
    {
    
        Task<(string AccessToken, Guid RefreshToken)> RefreshAccessTokenAsync(Guid oldRefreshToken);
        Task<bool> LogoutAsync(Guid refreshToken);
    }
}
