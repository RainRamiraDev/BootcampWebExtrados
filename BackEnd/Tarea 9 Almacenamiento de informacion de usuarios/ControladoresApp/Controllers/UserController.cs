using Microsoft.AspNetCore.Mvc;
using UserDaoLib.Dto;
using UserDaoLib.Services.Interfaces;
using System;
using ControladoresApp.Response;

namespace ControladoresApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null || !users.Any())
                {
                    var errors = new List<string> { "No se encontraron usuarios." };
                    var response = ApiResponse<List<UserDbReadDto>>.ErrorResponse(errors, "GetAllUsers: No se encontraron usuarios.");
                    return NotFound(response);
                }

                var userList = users.ToList();

                var successResponse = ApiResponse<List<UserDbReadDto>>.SuccessResponse("Usuarios encontrados.", userList);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener los usuarios." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<List<UserDbReadDto>>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDbAlterDto userDto)
        {
            try
            {
                var id = await _userService.CreateUserAsync(userDto);
                var response = ApiResponse<UserDbAlterDto>.SuccessResponse("Usuario creado exitosamente.", userDto);
                return CreatedAtAction(nameof(GetUserById), new { id }, response);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbAlterDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetUserById(int id, [FromQuery] string contrasenia)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    var errors = new List<string> { "Usuario no encontrado." };
                    var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, "GetUserById: No se pudo encontrar al usuario con ID: " + id);
                    return NotFound(response);
                }

                // Verificamos si la contraseña es válida
                var userModel = await _userService.LogInAsync(user.Nombre, contrasenia);
                if (userModel == null)
                {
                    var errors = new List<string> { "Contraseña incorrecta." };
                    var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, "GetUserById: La contraseña proporcionada es incorrecta.");
                    return Unauthorized(response); // Responde con un código 401 si la contraseña es incorrecta
                }

                var successResponse = ApiResponse<UserDbReadDto>.SuccessResponse("Usuario encontrado.", user);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener el usuario." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }


        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);
                if (user == null)
                {
                    var errors = new List<string> { "Usuario no encontrado." };
                    var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, "GetUserByEmail: No se pudo encontrar al usuario con Email: " + email);
                    return NotFound(response);
                }
                var successResponse = ApiResponse<UserDbReadDto>.SuccessResponse("Usuario encontrado.", user);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener el usuario." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDbAlterDto userDto)
        {
            try
            {
                var updated = await _userService.UpdateUserAsync(id, userDto);
                if (!updated)
                {
                    var errors = new List<string> { "No se pudo actualizar el usuario." };
                    var response = ApiResponse<UserDbAlterDto>.ErrorResponse(errors, "UpdateUser: El usuario con ID " + id + " no se pudo actualizar.");
                    return NotFound(response);
                }
                var successResponse = ApiResponse<UserDbAlterDto>.SuccessResponse("Usuario actualizado exitosamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al actualizar el usuario." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbAlterDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deleted = await _userService.DeleteUserAsync(id);
                if (!deleted)
                {
                    var errors = new List<string> { "No se pudo eliminar el usuario." };
                    var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, "DeleteUser: No se pudo eliminar el usuario con ID: " + id);
                    return NotFound(response);
                }
                var successResponse = ApiResponse<UserDbReadDto>.SuccessResponse("Usuario eliminado exitosamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al eliminar el usuario." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }
    }
}
