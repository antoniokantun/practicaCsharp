﻿using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ApplicationCore.Commands;

namespace Infraestructure.Services
{
    public class EstudiantesService : IEstudiantesService
    {
        private readonly ApplicationDbContext _dbContext;

        public EstudiantesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<object>> GetEstudiantes()
        {
            object list = new object();
            list = await _dbContext.estudiante.ToListAsync();
            return new Response<object>(list);
        }

        public async Task<Response<object>> GetEstudianteById(int id)
        {
            try
            {
                var estudiante = await _dbContext.estudiante.FindAsync(id);

                if (estudiante == null)
                {
                    return new Response<object>(null, "Estudiante no encontrado");
                }

                return new Response<object>(estudiante);
            }
            catch (Exception ex)
            {
                return new Response<object>(null, $"Error al obtener el estudiante: {ex.Message}");
            }
        }

        public async Task<Response<int>> UpdateEstudiante(EstudianteCreateCommand request)
        {
            try
            {
                var estudiante = await _dbContext.estudiante.FindAsync(request.Id);

                if (estudiante == null)
                {
                    return new Response<int>(0, "Estudiante no encontrado");
                }

                // Actualizar las propiedades del estudiante
                estudiante.nombre = request.Nombre;
                estudiante.edad = request.Edad;
                estudiante.correo = request.Correo;

                await _dbContext.SaveChangesAsync();

                return new Response<int>(estudiante.Id, "Estudiante actualizado correctamente");
            }
            catch (Exception ex)
            {
                return new Response<int>(0, $"Error al actualizar el estudiante: {ex.Message}");
            }
        }

        public async Task<Response<int>> DeleteEstudiante(int id)
        {
            try
            {
                var estudiante = await _dbContext.estudiante.FindAsync(id);

                if (estudiante == null)
                {
                    return new Response<int>(0, "Estudiante no encontrado");
                }

                _dbContext.estudiante.Remove(estudiante);
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
