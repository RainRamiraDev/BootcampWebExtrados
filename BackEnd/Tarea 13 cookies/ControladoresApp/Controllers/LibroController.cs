using Configuration;
using ControladoresApp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserDaoLib.Dto;
using UserDaoLib.Dto.Libro;
using UserDaoLib.Services;
using UserDaoLib.Services.Interfaces;

namespace ControladoresApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLibros()
        {
            try
            {
                var libros = await _libroService.GetAllLibrosAsync();

                if (libros == null || !libros.Any())
                {
                    return NotFound(ApiResponse<IEnumerable<LibroDbReadDto>>.ErrorResponse("Libros no encontrados."));
                }

                var response = ApiResponse<IEnumerable<LibroDbReadDto>>.SuccessResponse("Libros obtenidos exitosamente.", libros);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { "Ocurrió un error al obtener los libros." };
                var stackTrace = ex.StackTrace;
                var response = ApiResponse<UserDbReadDto>.ErrorResponse(errors, stackTrace);
                return BadRequest(response);
            }
        }

    }
}
