using System;
using AutoMapper;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Application.DTO;

namespace Quala.AdminSucursales.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
            CreateMap<Moneda, MonedaDTO>().ReverseMap();
        }
    }
}
