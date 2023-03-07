using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Entities
{

    public class Projection
    {
        
        public string idWeek { get; set; }
        public string idUser { get; set; }
    }



    public class Details
    {
        public string idUser { get; set; }
        public string amount { get; set; }
        public string paymenteAmount { get; set; }
        public string idProjection { get; set; }
        public string idDay { get; set; }
        public string idClient { get; set; }
        public string idInvoice { get; set; }
        public string idDigital { get; set; }
        public string installation { get; set; }
        public string paymentDate { get; set; }
        public string type { get; set; }
    }

}
