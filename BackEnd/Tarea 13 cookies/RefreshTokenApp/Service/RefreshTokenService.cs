using RefreshTokenApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Daos.Interfaces;

namespace RefreshTokenApp.Service
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenDao _refreshTokenDao;

        public RefreshTokenService(IRefreshTokenDao refreshTokenDao)
        {
            _refreshTokenDao = refreshTokenDao ?? throw new ArgumentNullException(nameof(refreshTokenDao));
        }

        public async Task<(string AccessToken, Guid RefreshToken)> RefreshAccessTokenAsync(Guid oldRefreshToken)
        {
            // Validar que el refresh token exista y sea válido
            var refreshTokenData = await _refreshTokenDao.GetRefreshTokenAsync(oldRefreshToken);
            if (refreshTokenData == null || refreshTokenData.ExpirationDate <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token.");
            }

            // Eliminar el refresh token anterior
            await _refreshTokenDao.DeleteRefreshTokenAsync(oldRefreshToken);

            // Generar un nuevo access token y refresh token
            string newAccessToken = GenerateAccessToken(refreshTokenData.UserId);
            Guid newRefreshToken = Guid.NewGuid();
            DateTime expirationDate = DateTime.UtcNow.AddDays(7);

            // Guardar el nuevo refresh token
            await _refreshTokenDao.SaveRefreshTokenAsync(newRefreshToken, refreshTokenData.UserId, expirationDate);

            return (newAccessToken, newRefreshToken);
        }

        public async Task<bool> LogoutAsync(Guid refreshToken)
        {
            // Eliminar el refresh token de la base de datos
            var rowsAffected = await _refreshTokenDao.DeleteRefreshTokenAsync(refreshToken);
            return rowsAffected > 0;
        }

        private string GenerateAccessToken(int userId)
        {
            // Implementar lógica para generar el token de acceso (e.g., JWT)
            // Aquí debes incluir las claims necesarias para identificar al usuario
            return $"new_access_token_for_user_{userId}"; // Placeholder
        }
    }
}
