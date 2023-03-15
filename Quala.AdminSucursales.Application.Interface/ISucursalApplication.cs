using System;
using System.Collections.Generic;
using System.Text;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Transversal.Common;


namespace Quala.AdminSucursales.Application.Interface
{
    public interface ISucursalApplication
    {
        Response<IEnumerable<SucursalDTO>> GetSucursales();
        Response<SucursalDTO> GetSucursalByCodigo(int codigo);
        Response<bool> InsertSucursales(SucursalDTO sucursalesDTO);
        Response<bool> UpdateSucursales(SucursalDTO sucursalesDTO);
        Response<bool> DeleteSucursales(int codigo);
    }
}
