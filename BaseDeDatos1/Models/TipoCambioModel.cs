using System;
using System.ComponentModel.DataAnnotations; // Para las validaciones

namespace BaseDeDatos1.Models
{
    public class TipoCambioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La moneda de origen es obligatoria.")]
        [StringLength(3, ErrorMessage = "La moneda de origen no puede tener más de 3 caracteres.")]
        public string MonedaOrigen { get; set; }

        [Required(ErrorMessage = "La moneda de destino es obligatoria.")]
        [StringLength(3, ErrorMessage = "La moneda de destino no puede tener más de 3 caracteres.")]
        public string MonedaDestino { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La fecha no es válida.")]
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de cambio de compra es obligatorio.")]
        [Range(0, 100000000, ErrorMessage = "El tipo de cambio de compra debe ser un valor numérico entre 0 y 100000000.")]
        public decimal TipoDeCambioCompra { get; set; }

        [Required(ErrorMessage = "El tipo de cambio de venta es obligatorio.")]
        [Range(0, 100000000, ErrorMessage = "El tipo de cambio de venta debe ser un valor numérico entre 0 y 100000000.")]
        public decimal TipoDeCambioVenta { get; set; }
    }
}