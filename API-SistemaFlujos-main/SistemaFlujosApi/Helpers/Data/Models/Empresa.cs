using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            LineasCreditos = new HashSet<LineasCredito>();
        }

        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public int? Instalacion { get; set; }

        public virtual ICollection<LineasCredito> LineasCreditos { get; set; }
    }
}
