//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caja_Unapec
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MOVIMIENTO
    {
        public int IdMovimiento { get; set; }
        [Required]
        public System.DateTime Fecha { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "El monto no puede ser menor a 1")]
        public double Monto { get; set; }

        public bool Estado { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdServicio { get; set; }
        [Required]
        public int IdDocumento { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public int IdFormaPago { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual DOCUMENTO DOCUMENTO { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual FORMA_PAGO FORMA_PAGO { get; set; }
        public virtual SERVICIO SERVICIO { get; set; }
    }
}
