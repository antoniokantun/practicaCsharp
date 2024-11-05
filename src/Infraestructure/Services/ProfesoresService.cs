using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class ProfesoresService : IProfesoresService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfesoresService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<object>> GetProfesores()
        {
            object list = new object();
            list = await _dbContext.profesor.ToListAsync();
            return new Response<object>(list);
        }

        public async Task<Response<object>> GetProfesorById(int id)
        {
            try
            {
                var profesor = await _dbContext.profesor.FindAsync(id);

                if (profesor == null)
                {
                    return new Response<object>(null, "Estudiante no encontrado");
                }

                return new Response<object>(profesor);
            }
            catch (Exception ex)
            {
                return new Response<object>(null, $"Error al obtener el estudiante: {ex.Message}");
            }
        }

        public async Task<Response<int>> UpdateProfesor(ProfesorCreateCommand request)
        {
            try
            {
                var profesor = await _dbContext.profesor.FindAsync(request.Id);

                if (profesor == null)
                {
                    return new Response<int>(0, "Estudiante no encontrado");
                }

                // Actualizar las propiedades del estudiante
                profesor.nombre = request.Nombre;
                profesor.edad = request.Edad;
                profesor.correo = request.Correo;

                await _dbContext.SaveChangesAsync();

                return new Response<int>(profesor.Id, "Estudiante actualizado correctamente");
            }
            catch (Exception ex)
            {
                return new Response<int>(0, $"Error al actualizar el estudiante: {ex.Message}");
            }
        }

        public async Task<Response<int>> DeleteProfesor(int id)
        {
            try
            {
                var profesor = await _dbContext.profesor.FindAsync(id);

                if (profesor == null)
                {
                    return new Response<int>(0, "Estudiante no encontrado");
                }

                _dbContext.profesor.Remove(profesor);
                await _dbContext.SaveChangesAsync();

                return new Response<int>(id, "Estudiante eliminado correctamente");
            }
            catch (Exception ex)
            {
                return new Response<int>(0, $"Error al eliminar el estudiante: {ex.Message}");
            }
        }
    }
}
