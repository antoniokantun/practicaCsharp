using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesService _service;

        public EstudiantesController(IEstudiantesService service)
        {
            _service = service;
        }

        [HttpGet("getEstudiante")]
        public async Task<IActionResult> GetEstudiantes()
        {
            var result = await _service.GetEstudiantes();
            return Ok(result);
        }

    }
}
