using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class RolesAsignado
    {
        public int IdPermiso { get; set; }
        public int RolId { get; set; }
        public int UsuarioId { get; set; }
        public bool EsActivo { get; set; }
    }
}
