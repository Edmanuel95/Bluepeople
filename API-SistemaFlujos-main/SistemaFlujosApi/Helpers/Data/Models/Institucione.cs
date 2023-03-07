using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Institucione
    {
        public int IdInstitucion { get; set; }
        public string Descripcion { get; set; }
        public bool? EsActivo { get; set; }
    }
}
