using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? RolId { get; set; }
        public string Correo { get; set; }
        public bool? EsActivo { get; set; }

        public virtual Proyeccion IdUsuario1 { get; set; }
        public virtual DetalleProyeccion IdUsuarioNavigation { get; set; }
    }
}
