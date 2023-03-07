using System;
using System.Collections.Generic;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class CobradoReal
    {
        public int IdCobradoReal { get; set; }
        public int ClienteId { get; set; }
        public decimal MontoCobradoReal { get; set; }
        public DateTime FechaCobro { get; set; }
        public int UsuarioId { get; set; }
        public int? DetalleProyeccionId { get; set; }
        public int? DiaSemanaId { get; set; }

        public virtual DetalleProyeccion DetalleProyeccion { get; set; }
    }
    public class requestCobradoReal
    {
       public int week { get; set; }
       public int idClient { get; set; }
    }

    public class requestNew
    {
        public string idUser { get; set; }
        public string idClient { get; set; }
        public string idProjection { get; set; }
        public string collectionDate { get; set; }
        public string amount { get; set; }
    }
    public class CollectionReal
    {
        public int idClient { get; set; }
        public int idProjection { get; set; }
        public string client { get; set; }
        public float mon { get; set; }
        public float tue { get; set; }
        public float wed { get; set; }
        public float thu { get; set; }
        public float fri { get; set; }
        public float sat { get; set; }
        public float total { get; set; }
    }


    public class ProjectionVsReal { 
        public int idClient { get; set; }
        public int idProjection { get; set; }
        public string client { get; set; }
        public float mon { get; set; }
        public float tue { get; set; }
        public float wed { get; set; }
        public float thu { get; set; }
        public float fri { get; set; }
        public float total { get; set; }
        public float sat { get; set; }
        public int isProyecion { get; set; }
    }

   

}
