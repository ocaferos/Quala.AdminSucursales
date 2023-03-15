using Quala.AdminSucursales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quala.AdminSucursales.Domain.Interface
{
    public interface IMonedaDomain
    {
        IEnumerable<Moneda> GetMonedas();
        Moneda GetMonedaByiD(int codigoMoneda);
    }
}
