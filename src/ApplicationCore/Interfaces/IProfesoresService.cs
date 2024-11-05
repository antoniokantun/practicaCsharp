using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProfesoresService
    {
        Task<Response<object>> GetProfesores();
        Task<Response<object>> GetProfesorById(int id);
        Task<Response<int>> DeleteProfesor(int id);
        Task<Response<int>> UpdateProfesor(ProfesorCreateCommand profesor);
    }
}
