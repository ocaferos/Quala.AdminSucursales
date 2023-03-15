using AutoMapper;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Application.Interface;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Domain.Interface;
using Quala.AdminSucursales.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Quala.AdminSucursales.Application.Main
{
    public class MonedaApplication : IMonedaApplication
    {

        private readonly IMonedaDomain _monedaDomain;
        private readonly IMapper _mapper;

        public MonedaApplication(IMonedaDomain monedaDomain, IMapper mapper)
        {
            _monedaDomain = monedaDomain;
            _mapper = mapper;
        }

        public Response<MonedaDTO> GetMonedaByCodigo(int codigo)
        {
            var response = new Response<MonedaDTO>();
            try
            {
                Moneda moneda = _monedaDomain.GetMonedaByiD(codigo);
                response.Data = _mapper.Map<MonedaDTO>(moneda);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<MonedaDTO>> GetMonedas()
        {
            var response = new Response<IEnumerable<MonedaDTO>>();
            try
            {
                var monedas = _monedaDomain.GetMonedas();
                response.Data = _mapper.Map<IEnumerable<MonedaDTO>>(monedas);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
