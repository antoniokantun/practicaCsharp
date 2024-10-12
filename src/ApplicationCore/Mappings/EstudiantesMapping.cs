using ApplicationCore.Commands;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappings
{
    public class EstudiantesMapping : Profile
    {
        public EstudiantesMapping()
        {
            CreateMap<EstudianteCreateCommand, Estudiante>().ForMember(x =>x.Id, y =>y.Ignore());
        }
    }
}
