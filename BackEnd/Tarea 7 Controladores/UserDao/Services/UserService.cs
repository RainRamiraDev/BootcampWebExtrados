

using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Dto;
using UserDaoLib.Models;
using UserDaoLib.Services.Interfaces;

namespace UserDaoLib.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public async Task<int> CreateUserAsync(UserDbAlterDto userDto)
        {
            var userModel = new UserModel
            {
                Nombre = userDto.Nombre,
                Email = userDto.Email,
                Edad = userDto.Edad
            };

            return await _userDao.CreateAsync(userModel);
        }
        public async Task<UserDbReadDto> GetUserByIdAsync(int id)
        {
            var userModel = await _userDao.GetByIdAsync(id);
            if (userModel == null) return null;

            return new UserDbReadDto
            {
                Id = userModel.Id,
                Nombre = userModel.Nombre,
                Email = userModel.Email,
                Edad = userModel.Edad
            };
        }
        public async Task<IEnumerable<UserDbReadDto>> GetAllUsersAsync()
        {
            var userModels = await _userDao.GetAllAsync();
            return userModels.Select(user => new UserDbReadDto
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Email = user.Email,
                Edad = user.Edad
            });
        }
        public async Task<bool> UpdateUserAsync(int id,UserDbAlterDto userDto)
        {
            var userModel = new UserModel
            {
                Id = id,
                Nombre = userDto.Nombre,
                Email = userDto.Email,
                Edad = userDto.Edad
            };

            return await _userDao.UpdateAsync(userModel);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userDao.DeleteAsync(id);
        }
        public async Task<UserDbReadDto> GetUserByEmailAsync(string email)
        {
            var userModel = await _userDao.GetByEmailAsync(email);

            if (userModel == null) return null;

            return new UserDbReadDto
            {
                Id = userModel.Id,
                Nombre = userModel.Nombre,
                Email = userModel.Email,
                Edad = userModel.Edad
            };
        }
    }

}
