

using UserDaoLib.Dto;
using UserDaoLib.Models;

namespace UserDaoLib.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateWhitHashedPasswordAsync(UserDbAlterDto userDto);
        Task<UserDbReadDto> GetUserWhitTokenAsync(int id);
        Task<UserModel> LogInAsync(string nombre, string contrasenia);
    }
}
