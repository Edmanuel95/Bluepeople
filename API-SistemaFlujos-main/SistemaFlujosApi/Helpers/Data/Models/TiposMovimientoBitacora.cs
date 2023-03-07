using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class TiposMovimientoBitacora
    {
        public int IdTipoMovimiento { get; set; }
        public string Seccion { get; set; }
        public string Descripcion { get; set; }
    }
}
