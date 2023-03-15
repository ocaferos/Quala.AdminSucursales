using System;
using AutoMapper;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Application.Interface;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Domain.Interface;
using Quala.AdminSucursales.Transversal.Common;
using System.Collections.Generic;


namespace Quala.AdminSucursales.Application.Main
{
    public class SucursalApplication : ISucursalApplication
    {
        private readonly ISucursalDomain _sucursalDomain;
        private readonly IMapper _mapper;

        public SucursalApplication(ISucursalDomain sucursalDomain, IMapper mapper)
        {
            _sucursalDomain = sucursalDomain;
            _mapper = mapper;
        }

        public Response<bool> DeleteSucursales(int codigo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _sucursalDomain.DeleteSucursales(codigo);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<SucursalDTO> GetSucursalByCodigo(int codigo)
        {
            var response = new Response<SucursalDTO>();
            try
            {
                Sucursal sucursal = _sucursalDomain.GetSucursalByCodigo(codigo);
                response.Data = _mapper.Map<SucursalDTO>(sucursal);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!!!";
                }
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<SucursalDTO>> GetSucursales()
        {
            var response = new Response<IEnumerable<SucursalDTO>>();
            try
            {
                var sucursal = _sucursalDomain.GetSucursales();
                response.Data = _mapper.Map<IEnumerable<SucursalDTO>>(sucursal);
                if(response.Data != null)
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

        public Response<bool> InsertSucursales(SucursalDTO sucursalesDTO)
        {
            var response = new Response<bool>();
            try
            {
                var sucursal = _mapper.Map<Sucursal>(sucursalesDTO);
                response.Data = _sucursalDomain.InsertSucursales(sucursal);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> UpdateSucursales(SucursalDTO sucursalesDTO)
        {
            var response = new Response<bool>();
            try
            {
                var sucursal = _mapper.Map<Sucursal>(sucursalesDTO);
                response.Data = _sucursalDomain.UpdateSucursales(sucursal);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!!!";
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
