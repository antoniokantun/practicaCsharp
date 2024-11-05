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
    public class ProfesoresMapping : Profile
    {
        public ProfesoresMapping()
        {
            CreateMap<ProfesorCreateCommand, Profesor>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}
