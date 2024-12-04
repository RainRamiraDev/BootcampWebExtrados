

using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Dto;
using UserDaoLib.Models;
using UserDaoLib.Services.Interfaces;
using UserDaoLib.Daos.Security; // Importamos la clase PasswordHasher para la seguridad de las contraseñas

namespace UserDaoLib.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;
        private PasswordHasher _passwordHasher;

        public UserService(IUserDao userDao, PasswordHasher passwordHasher)
        {
            _userDao = userDao;
            _passwordHasher = passwordHasher;
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


        public async Task<int> CreateUserAsync(UserDbAlterDto userDto)
        {
            // Hashea la contraseña antes de guardarla
            string hashedPassword = _passwordHasher.HashPassword(userDto.Contrasenia);

            var userModel = new UserModel
            {
                Nombre = userDto.Nombre,
                Email = userDto.Email,
                Contrasenia = hashedPassword // Asignamos la contraseña hasheada
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
                Email = userModel.Email
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
                Contrasenia = user.Contrasenia // Solo devolvemos el hash de la contraseña, nunca la contraseña en texto claro
            });
        }


        public async Task<bool> UpdateUserAsync(int id, UserDbAlterDto userDto)
        {
            // Hashea la contraseña si ha sido cambiada
            string hashedPassword = _passwordHasher.HashPassword(userDto.Contrasenia);

            var userModel = new UserModel
            {
                Id = id,
                Nombre = userDto.Nombre,
                Email = userDto.Email,
                Contrasenia = hashedPassword // Asignamos la contraseña hasheada
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
                Email = userModel.Email
            };
        }
    }
}
