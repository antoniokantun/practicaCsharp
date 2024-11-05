using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/profesores")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesoresService _service;
        private readonly IMediator _mediator;

        public ProfesoresController(IProfesoresService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet("getProfesor")]
        public async Task<IActionResult> GetProfesores()
        {
            var result = await _service.GetProfesores();
            return Ok(result);
        }

        [HttpPost("createProfesor")]
        public async Task<ActionResult<Response<int>>> CreateProfesor(ProfesorCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("deleteProfesor/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteProfesor(int id)
        {
            var result = await _service.DeleteProfesor(id);
            return Ok(result);
        }

        [HttpGet("getProfesor/{id}")]
        public async Task<IActionResult> GetProfesorById(int id)
        {
            var result = await _service.GetProfesorById(id);
            return Ok(result);
        }

        [HttpPut("updateProfesor")]
        public async Task<ActionResult<Response<int>>> UpdateProfesor([FromBody] ProfesorCreateCommand command)
        {
            var result = await _service.UpdateProfesor(command);
            return Ok(result);
        }
    }
}
