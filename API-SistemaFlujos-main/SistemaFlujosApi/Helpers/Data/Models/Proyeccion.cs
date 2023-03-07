using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Proyeccion
    {
        public Proyeccion()
        {
            DetalleProyeccions = new HashSet<DetalleProyeccion>();
        }

        public int IdProyeccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int SemanaId { get; set; }
        public int UsuarioId { get; set; }
        public bool? EsActivo { get; set; }
        public int? EmpresaId { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Semana Semana { get; set; }
        public virtual ICollection<DetalleProyeccion> DetalleProyeccions { get; set; }
    }
}
