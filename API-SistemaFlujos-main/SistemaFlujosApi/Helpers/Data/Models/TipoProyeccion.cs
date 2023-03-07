using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class TipoProyeccion
    {
        public int IdTipoProyeccion { get; set; }
        public string TipoProyeccion1 { get; set; }
        public bool EsActivo { get; set; }
        public int DepartamentoId { get; set; }
    }
}
