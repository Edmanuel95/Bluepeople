using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class TiposLinea
    {
        public TiposLinea()
        {
            LineasCreditos = new HashSet<LineasCredito>();
        }

        public int IdTipoLinea { get; set; }
        public string Descripcion { get; set; }
        public bool EsSaldoInicial { get; set; }
        public bool? EsActivo { get; set; }

        public virtual ICollection<LineasCredito> LineasCreditos { get; set; }
    }
}
