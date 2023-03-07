using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public int UsuarioId { get; set; }
        public int ReferenciaId { get; set; }
        public int TipoMovimientoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public bool EsActivo { get; set; }
        public string Descripcion { get; set; }
        public int? SesionId { get; set; }
    }
}
