using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class ColaboradoresController : ControllerBase
    {
        private readonly IEstudiantesService _service;
        private readonly IMediator _mediator;

        public ColaboradoresController(IEstudiantesService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Response<int>>> Create([FromBody] ColaboradorCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
