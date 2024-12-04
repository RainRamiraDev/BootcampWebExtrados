

using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Dto;
using UserDaoLib.Models;
using UserDaoLib.Services.Interfaces;
using UserDaoLib.Daos.Security;

namespace UserDaoLib.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;
        private readonly PasswordHasher _passwordHasher;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
            _passwordHasher = new PasswordHasher();
        }

        public async Task<int> CreateWhitHashedPasswordAsync(UserDbAlterDto userDto)
        {
            string hashedPassword = _passwordHasher.HashPassword(userDto.Contrasenia);

            var userModel = new UserModel
            {
                Nombre = userDto.Nombre,
                Email = userDto.Email,
                Contrasenia = hashedPassword
            };

            return await _userDao.CreateWhitHashedPasswordAsync(userModel);
        }

        public async Task<UserDbReadDto> GetUserWhitTokenAsync(int id)
        {
            var userModel = await _userDao.GetUserWhitTokenAsync(id);
            if (userModel == null) return null;

            return new UserDbReadDto
            {
                Id = userModel.Id,
                Nombre = userModel.Nombre,
                Email = userModel.Email
            };
        }

        public async Task<UserModel> LogInAsync(string nombre, string contrasenia)
        {
            var user = await _userDao.LogInAsync(nombre);
            if (user == null)
            {
                return null;
            }

            bool isPasswordValid = _passwordHasher.VerifyPassword(contrasenia, user.Contrasenia);
            if (!isPasswordValid)
            {
                return null;
            }

            return user;
        }


    }
}
