﻿using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
    }
}