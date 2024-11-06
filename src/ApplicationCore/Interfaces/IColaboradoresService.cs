using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IColaboradoresService
    {
        Task<Response<object>> GetColaboradores();
        Task<Response<object>> GetColaboradorById(int id);
        Task<Response<int>> DeleteColaborador(int id);
        Task<Response<int>> UpdateColaborador(ColaboradorCreateCommand Colaborador);
    }
}
