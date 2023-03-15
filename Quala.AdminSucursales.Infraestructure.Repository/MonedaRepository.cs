using Dapper;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Infraestructure.Interface;
using Quala.AdminSucursales.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Quala.AdminSucursales.Infraestructure.Repository
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MonedaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Moneda GetMonedaByCodigo(int codigo)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var query = "MonedaGetById";

                var parameters = new DynamicParameters();
                parameters.Add("@CodigoMoneda", codigo);
                var moneda = connection.QuerySingle<Moneda>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return moneda;
            }
        }

        public IEnumerable<Moneda> GetMonedas()
        {
            using(var connection = _connectionFactory.GetConnection) {
                var query = "MonedaList";
                var monedas = connection.Query<Moneda>(query, commandType: CommandType.StoredProcedure);
                return monedas;
                
            }
        }
    }
}
