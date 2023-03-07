using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class LineasCredito
    {
        public int IdLineaCredito { get; set; }
        public string Descripcion { get; set; }
        public int TipoLineaId { get; set; }
        public int InstitucionId { get; set; }
        public decimal MontoLinea { get; set; }
        public string TasaInteres { get; set; }
        public int EmpresaId { get; set; }
        public string Observaciones { get; set; }
        public double? Aforo { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public decimal SaldoDispuesto { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal? MontoTransito { get; set; }
        public bool? EsActivo { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual TiposLinea TipoLinea { get; set; }
    }
}
