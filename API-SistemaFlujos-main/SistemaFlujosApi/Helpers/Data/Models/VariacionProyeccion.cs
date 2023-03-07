using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class VariacionProyeccion
    {
        public int IdVariacionProyeccion { get; set; }
        public int DetalleProyeccionId { get; set; }
        public decimal MontoVariacion { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }

        public virtual DetalleProyeccion DetalleProyeccion { get; set; }
    }
}
