using System.Data;

namespace Quala.AdminSucursales.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
