using System;
using Quala.AdminSucursales.Domain.Interface;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Infraestructure.Interface;
using System.Collections.Generic;

namespace Quala.AdminSucursales.Domain.Core
{
    public class SucursalDomain : ISucursalDomain
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalDomain(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public bool DeleteSucursales(int codigo)
        {
            return _sucursalRepository.DeleteSucursales(codigo);
        }

        public Sucursal GetSucursalByCodigo(int codigo)
        {
            return _sucursalRepository.GetSucursalByCodigo(codigo);
        }

        public IEnumerable<Sucursal> GetSucursales()
        {
            return _sucursalRepository.GetSucursales();
        }

        public bool InsertSucursales(Sucursal sucursales)
        {
            return _sucursalRepository.InsertSucursales(sucursales);
        }

        public bool UpdateSucursales(Sucursal sucursales)
        {
            return _sucursalRepository.UpdateSucursales(sucursales);
        }
    }
}
