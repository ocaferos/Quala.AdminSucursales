﻿using System;

namespace Quala.AdminSucursales.Domain.Entity
{
    public class Sucursal
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public string Codigo_Moneda { get; set; }
    }
}
