using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands
{
    public class ColaboradorCreateCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsProfesor { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }  // Para profesor
        public string Puesto { get; set; }        // Para administrativo
        public string Nomina { get; set; }        // Para administrativo
    }
}
