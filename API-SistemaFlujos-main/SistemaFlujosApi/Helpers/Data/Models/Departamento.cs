using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int? EmpresaId { get; set; }
        public bool? EsActivo { get; set; }
    }
}
