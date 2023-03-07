using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Concepto
    {
        public int IdConcepto { get; set; }
        public int ClasificacionId { get; set; }
        public string Descripcion { get; set; }
        public bool EsIngreso { get; set; }
        public bool EsSaldoInicial { get; set; }
        public int? OrdenColumna { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool EsActivo { get; set; }
    }
}
