using System;
using Quala.AdminSucursales.Transversal.Common;
using Quala.AdminSucursales.Infraestructure.Interface;
using Quala.AdminSucursales.Domain.Entity;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Quala.AdminSucursales.Infraestructure.Repository
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SucursalRepository (IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool DeleteSucursales(int codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SucursalDelete";
                var parameters = new DynamicParameters();
                parameters.Add("Codigo", codigo);
                var result = connection.Execute(query, param : parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Sucursal GetSucursalByCodigo(int codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SucursalGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("Codigo", codigo);
                var sucursal = connection.QuerySingle<Sucursal>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return sucursal;
            }
        }

        public IEnumerable<Sucursal> GetSucursales()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SucursalList";
                var sucursales = connection.Query<Sucursal>(query, commandType: CommandType.StoredProcedure);
                return sucursales;
            }
        }

        public bool InsertSucursales(Sucursal sucursales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                sucursales.Fecha_Creacion = DateTime.Now;
                var query = "SucursalInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Descripcion", sucursales.Descripcion);
                parameters.Add("Direccion", sucursales.Direccion);
                parameters.Add("Identificacion", sucursales.Identificacion);
                parameters.Add("FechaCreacion", sucursales.Fecha_Creacion);
                parameters.Add("CodigoMoneda", sucursales.Codigo_Moneda);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool UpdateSucursales(Sucursal sucursales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                sucursales.Fecha_Creacion = DateTime.Now;
                var query = "SucursalUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("Codigo", sucursales.Codigo);
                parameters.Add("Descripcion", sucursales.Descripcion);
                parameters.Add("Direccion", sucursales.Direccion);
                parameters.Add("Identificacion", sucursales.Identificacion);
                parameters.Add("FechaCreacion", sucursales.Fecha_Creacion);
                parameters.Add("CodigoMoneda", sucursales.Codigo_Moneda);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
