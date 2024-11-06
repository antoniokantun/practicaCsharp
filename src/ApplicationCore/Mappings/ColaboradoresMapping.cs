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
    public class ColaboradoresMapping : Profile
    {
        public ColaboradoresMapping()
        {
            CreateMap<ColaboradorCreateCommand, Colaborador>()
                .ForMember(dest => dest.FechaCreacion,
                          opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<ColaboradorCreateCommand, Profesor>()
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento));

            CreateMap<ColaboradorCreateCommand, Administrativo>()
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.Puesto))
                .ForMember(dest => dest.Nomina, opt => opt.MapFrom(src => src.Nomina));
        }
    }
}
