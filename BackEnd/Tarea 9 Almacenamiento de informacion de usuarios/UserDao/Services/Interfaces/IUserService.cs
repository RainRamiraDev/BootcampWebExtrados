

using UserDaoLib.Dto;
using UserDaoLib.Models;

namespace UserDaoLib.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserDbAlterDto userDto);
        Task<UserDbReadDto> GetUserByIdAsync(int id);
        Task<UserDbReadDto> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDbReadDto>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(int id,UserDbAlterDto userDto);
        Task<bool> DeleteUserAsync(int id);

        Task<UserModel> LogInAsync(string nombre, string contrasenia);
    }
}
