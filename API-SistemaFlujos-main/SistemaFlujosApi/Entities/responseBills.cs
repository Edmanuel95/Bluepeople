using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Entities
{

    public class responseBills
    {
        public Bill[] Bills { get; set; }
    }

    public class Bill
    {
        public float CLIENTE { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public float FACTURA { get; set; }
        public float SALDO { get; set; }
        public float IMPORTE { get; set; }
        public float SALDO_MN { get; set; }
        public string CANAL { get; set; }
    }



}
