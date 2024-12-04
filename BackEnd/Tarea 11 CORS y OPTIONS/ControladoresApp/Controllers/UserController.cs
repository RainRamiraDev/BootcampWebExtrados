using Microsoft.AspNetCore.Mvc;
using UserDaoLib.Dto;
using UserDaoLib.Services.Interfaces;
using System;
using ControladoresApp.Response;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Math;
using System.Net;
using Configuration;
using Microsoft.Extensions.Options;

namespace ControladoresApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly KeysConfiguration _keysConfiguration;

        public UserController(IUserService userService, IOptions<KeysConfiguration> keys)
        {
            _userService = userService;
            _keysConfiguration = keys.Value;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserWhitHashedPassword([FromBody] UserDbAlterDto userDto)
        {
            try
            {
                var userId = await _userService.CreateWhitHashedPasswordAsync(userDto);
                var user = new UserDbAlterDto
                {
                    Nombre = userDto.Nombre,
                    Email = userDto.Email,
                    Contrasenia = userDto.Contrasenia,
                };
                var response = ApiResponse<UserDbAlterDto>.SuccessResponse
                    (
                        "Usuario creado exitosamente",
                        userDto
                    );

                return Created(string.Empty, response);

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
        [Authorize]
        public async Task<IActionResult> GetUserWhitToken(int id)
        {
            try
            {
                var user = await _userService.GetUserWhitTokenAsync(id);

                if (user == null)
                {
                    return NotFound(ApiResponse<UserDbReadDto>.ErrorResponse("Usuario no encontrado."));
                }

                var response = ApiResponse<UserDbReadDto>.SuccessResponse("Usuario obtenido exitosamente.", user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener el usuario." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        [HttpGet("LogIn/{nombre}/{contrasenia}")]
        public async Task<IActionResult> LogIn(string nombre, string contrasenia)
        {
            try
            {
                var user = await _userService.LogInAsync(nombre, contrasenia);

                if (user == null)
                {
                    var errors = new List<string> { "Usuario no encontrado o contraseña incorrecta." };
                    var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, "LogIn: No se pudo encontrar al usuario con Nombre: " + nombre);
                    return NotFound(response);
                }

                // Utilizando las claves de JWT inyectadas
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_keysConfiguration.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _keysConfiguration.Issuer,
                    audience: _keysConfiguration.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al intentar iniciar sesión." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }
    }
}
