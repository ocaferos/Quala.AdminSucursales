using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quala.AdminSucursales.Application.Interface
{
    public interface IMonedaApplication
    {
        Response<IEnumerable<MonedaDTO>> GetMonedas();
        Response<MonedaDTO> GetMonedaByCodigo(int codigo);
    }
}
