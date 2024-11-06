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

        public async Task<Response<int>> Handle(ColaboradorCreateCommand command, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                // Crear el colaborador
                var colaborador = _mapper.Map<Colaborador>(command);
                await _context.AddAsync(colaborador, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                // Dependiendo de IsProfesor, crear el registro correspondiente
                if (command.IsProfesor)
                {
                    var profesor = _mapper.Map<Profesor>(command);
                    profesor.FkColaborador = colaborador.Id;
                    await _context.AddAsync(profesor, cancellationToken);
                }
                else
                {
                    var administrativo = _mapper.Map<Administrativo>(command);
                    administrativo.FkColaborador = colaborador.Id;
                    await _context.AddAsync(administrativo, cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new Response<int>(colaborador.Id, "Colaborador creado exitosamente");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new Response<int>(0, $"Error al crear el colaborador: {ex.Message}");
            }
        }
    }
}
