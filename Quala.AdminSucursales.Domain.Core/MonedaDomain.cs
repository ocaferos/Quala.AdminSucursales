using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Domain.Interface;
using Quala.AdminSucursales.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quala.AdminSucursales.Domain.Core
{
    public class MonedaDomain : IMonedaDomain
    {
        private readonly IMonedaRepository _monedaRepository;

        public MonedaDomain(IMonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }
        public Moneda GetMonedaByiD(int codigoMoneda)
        {
            return _monedaRepository.GetMonedaByCodigo(codigoMoneda);
        }

        public IEnumerable<Moneda> GetMonedas()
        {
            return _monedaRepository.GetMonedas();
        }
    }
}
