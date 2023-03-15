using System;
using System.Collections.Generic;
using System.Text;

namespace Quala.AdminSucursales.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
