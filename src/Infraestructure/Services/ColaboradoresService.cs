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
    public class ColaboradoresService : IColaboradoresService
    {
        private readonly ApplicationDbContext _dbContext;

        public ColaboradoresService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<object>> GetColaboradores()
        {
            object list = new object();
            list = await _dbContext.colaborador.ToListAsync();
            return new Response<object>(list);
        }

        public Task<Response<int>> DeleteColaborador(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> GetColaboradorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> UpdateColaborador(ColaboradorCreateCommand Colaborador)
        {
            throw new NotImplementedException();
        }
    }
}
