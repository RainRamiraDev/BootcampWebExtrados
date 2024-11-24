

using UserDaoLib.Dto;

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
    }
}
