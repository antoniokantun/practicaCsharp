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

       
    }
}
