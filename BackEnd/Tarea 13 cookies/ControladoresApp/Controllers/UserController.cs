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
using RefreshTokenApp.Service.Interface;

namespace ControladoresApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly KeysConfiguration _keysConfiguration;

        public UserController(IUserService userService, IOptions<KeysConfiguration> keys, IRefreshTokenService refreshToken)
        {
            _userService = userService;
            _refreshTokenService = refreshToken;
            _keysConfiguration = keys.Value;
        }

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
                    return NotFound(ApiResponse<UserDbReadDto>.ErrorResponse(
                        new List<string> { "Usuario no encontrado o contraseña incorrecta." },
                        $"LogIn: No se pudo encontrar al usuario con Nombre: {nombre}"
                    ));
                }

                var accessToken = _refreshTokenService.GenerateAccessToken(user.Id, user.Nombre, user.Email);

                Guid refreshToken = Guid.NewGuid();
                DateTime expirationDate = DateTime.UtcNow.AddDays(7);

                await _refreshTokenService.SaveRefreshTokenAsync(refreshToken, user.Id, expirationDate);

                Response.Cookies.Append("RefreshToken", refreshToken.ToString(),
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = expirationDate
                    });

                return Ok(new { AccessToken = accessToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<UserDbReadDto>.ErrorResponse(
                    new List<string> { "Ocurrió un error al intentar iniciar sesión." },
                    ex.StackTrace
                ));
            }
        }



        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] Guid oldRefreshToken)
        {
            try
            {
                var refreshTokenFromCookie = Request.Cookies["RefreshToken"];

                if (string.IsNullOrEmpty(refreshTokenFromCookie))
                {
                    return Unauthorized(new { Message = "No se encontró el refresh token." });
                }

                var (newAccessToken, newRefreshToken) = await _refreshTokenService.RefreshAccessTokenAsync(Guid.Parse(refreshTokenFromCookie));

                Response.Cookies.Append("RefreshToken", newRefreshToken.ToString(),
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, 
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(7) 
                    });

                return Ok(new { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Ocurrió un error al intentar renovar el token.", Details = ex.Message });
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] Guid refreshToken)
        {
            try
            {
                bool result = await _refreshTokenService.LogoutAsync(refreshToken);

                if (!result)
                    return NotFound(new { Message = "El token no fue encontrado o ya se eliminó." });
 
                Response.Cookies.Append("RefreshToken", "", new CookieOptions
                {
                    Expires = DateTime.Now, 
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.Strict 
                });

                return Ok(new { Message = "Sesión cerrada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Ocurrió un error al intentar cerrar sesión.", Details = ex.Message });
            }
        }



    }
}
