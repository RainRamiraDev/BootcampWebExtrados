using ControladoresApp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserDaoLib.Dto.Libro;
using UserDaoLib.Dto.Prestamo;
using UserDaoLib.Services;
using UserDaoLib.Services.Interfaces;

namespace ControladoresApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [Authorize(Roles = "usuario")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPrestamosLibros()
        {
            try
            {
                var prestamos = await _prestamoService.GetAllPrestamoAsync();

                if (prestamos == null || ! prestamos.Any())
                {
                    return NotFound(ApiResponse<IEnumerable<PrestamoDbReadDto>>.ErrorResponse("Prestamos no encontrados."));
                }

                var response = ApiResponse<IEnumerable<PrestamoDbReadDto>>.SuccessResponse("Prestamos obtenidos exitosamente.", prestamos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener los prestamos." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<PrestamoDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }



        [Authorize(Roles = "usuario")]
        [HttpPost("create")]
        public async Task<IActionResult> CreatePrestamo([FromBody] PrestamoDbAlterDto prestamoDto)
        {
            try
            {
                var usuarioAutenticadoId = GetAuthenticatedUserId(); 

                if (prestamoDto.IdUsuario != usuarioAutenticadoId)
                {
                    return Unauthorized(ApiResponse<PrestamoDbAlterDto>.ErrorResponse("El usuario no está autorizado para realizar este préstamo."));
                }

                var id = await _prestamoService.CreatePrestamoAsync(prestamoDto);

                var fechaVencimiento = prestamoDto.FechaPrestamo;

                var prestamoResponse = new PrestamoDbAlterDto
                {
                    IdUsuario = prestamoDto.IdUsuario,
                    isbn = prestamoDto.isbn,
                    FechaPrestamo = prestamoDto.FechaPrestamo
                };

                var response = ApiResponse<PrestamoDbAlterDto>.SuccessResponse(
                    $"Prestamo creado exitosamente. Fecha de vencimiento: {fechaVencimiento.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}",
                    prestamoResponse
                );

                return CreatedAtAction(nameof(CreatePrestamo), new { id }, response);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al crear el préstamo." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<PrestamoDbAlterDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

        private int GetAuthenticatedUserId()
        {
            var usuarioIdClaim = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (usuarioIdClaim != null && int.TryParse(usuarioIdClaim.Value, out var usuarioId))
            {
                return usuarioId;
            }
            else
            {
                throw new UnauthorizedAccessException("Usuario no autenticado.");
            }
        }


    }
}
