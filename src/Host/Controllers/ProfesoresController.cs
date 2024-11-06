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

        
    }
}
