using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Colaboradores
{
    public class CreateColaboradorHandler : IRequestHandler<ColaboradorCreateCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateColaboradorHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ColaboradorCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Crear el colaborador
                var colaborador = _mapper.Map<Colaborador>(request);
                await _context.colaborador.AddAsync(colaborador, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                // Dependiendo de IsProfesor, crear el registro correspondiente
                if (request.IsProfesor)
                {
                    var profesor = _mapper.Map<Profesor>(request);
                    profesor.FkColaborador = colaborador.Id;
                    await _context.profesor.AddAsync(profesor, cancellationToken);
                }
                else
                {
                    var administrativo = _mapper.Map<Administrativo>(request);
                    administrativo.FkColaborador = colaborador.Id;
                    await _context.administrativo.AddAsync(administrativo, cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new Response<int>(colaborador.Id, "Colaborador creado exitosamente");
            }
            catch (Exception ex)
            {
                return new Response<int>(0, $"Error al crear el colaborador: {ex.Message}");
            }
        }
    }
}
