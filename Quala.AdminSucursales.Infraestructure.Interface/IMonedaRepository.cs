using Quala.AdminSucursales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quala.AdminSucursales.Infraestructure.Interface
{
    public interface IMonedaRepository
    {
        IEnumerable<Moneda> GetMonedas();
        Moneda GetMonedaByCodigo(int codigo);
    }
}
