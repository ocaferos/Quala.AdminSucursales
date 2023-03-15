using System;
using System.Collections.Generic;
using System.Text;
using Quala.AdminSucursales.Domain.Entity;

namespace Quala.AdminSucursales.Infraestructure.Interface
{
    public interface ISucursalRepository
    {
        IEnumerable<Sucursal> GetSucursales();
        Sucursal GetSucursalByCodigo(int codigo);
        bool InsertSucursales(Sucursal sucursales);
        bool UpdateSucursales(Sucursal sucursales);
        bool DeleteSucursales(int codigo);

    }
}
