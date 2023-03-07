using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Semana
    {
        public Semana()
        {
            Proyeccions = new HashSet<Proyeccion>();
        }

        public int IdSemana { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int? NumeroSemana { get; set; }

        public virtual ICollection<Proyeccion> Proyeccions { get; set; }
    }
}
