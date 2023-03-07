using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class DetalleProyeccion
    {
        public DetalleProyeccion()
        {
            CobradoReals = new HashSet<CobradoReal>();
            VariacionProyeccions = new HashSet<VariacionProyeccion>();
        }

        public int IdDetalleProyeccion { get; set; }
        public int ProyeccionId { get; set; }
        public decimal MontoProyectado { get; set; }
        public decimal? MontoReal { get; set; }
        public int DiaSemanaId { get; set; }
        public bool EsProyectado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsActivo { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? FechaProyeccion { get; set; }
        public int? ConceptoId { get; set; }

        public virtual DiaSemana DiaSemana { get; set; }
        public virtual Proyeccion Proyeccion { get; set; }
        public virtual ICollection<CobradoReal> CobradoReals { get; set; }
        public virtual ICollection<VariacionProyeccion> VariacionProyeccions { get; set; }
    }
}
