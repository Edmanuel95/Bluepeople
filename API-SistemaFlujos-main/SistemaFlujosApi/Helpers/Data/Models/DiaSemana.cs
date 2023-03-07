using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class DiaSemana
    {
        public DiaSemana()
        {
            DetalleProyeccions = new HashSet<DetalleProyeccion>();
        }

        public int IdDiaSemana { get; set; }
        public string Dia { get; set; }
        public int Ordenamiento { get; set; }

        public virtual ICollection<DetalleProyeccion> DetalleProyeccions { get; set; }
    }
}
