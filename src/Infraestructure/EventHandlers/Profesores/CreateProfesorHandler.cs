using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Profesores
{
    public class CreateProfesorHandler : IRequestHandler<ProfesorCreateCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProfesoresService _service;

        public CreateProfesorHandler(ApplicationDbContext context, IMapper mapper, IProfesoresService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<int>> Handle(ProfesorCreateCommand command, CancellationToken cancellationToken)
        {
            var e = new ProfesorCreateCommand();
            e.Nombre = command.Nombre;
            e.Edad = command.Edad;
            e.Correo = command.Correo;

            var es = _mapper.Map<Domain.Entities.Profesor>(e);
            await _context.AddAsync(es);
            var req = await _context.SaveChangesAsync(cancellationToken);
            return new Response<int>(es.Id, "Registro exitoso");
        }
    }
}
