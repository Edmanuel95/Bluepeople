using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Sesione
    {
        public int IdSesion { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Token { get; set; }
        public string Ip { get; set; }
        public bool EsActivo { get; set; }
        public string Extra { get; set; }
    }
}
