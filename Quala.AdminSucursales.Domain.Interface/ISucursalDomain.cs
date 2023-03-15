using Quala.AdminSucursales.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Quala.AdminSucursales.Domain.Interface
{
    public interface ISucursalDomain
    {
        IEnumerable<Sucursal> GetSucursales();
        Sucursal GetSucursalByCodigo(int codigo);
        bool InsertSucursales(Sucursal sucursales);
        bool UpdateSucursales(Sucursal sucursales);
        bool DeleteSucursales(int codigo);
    }
}
