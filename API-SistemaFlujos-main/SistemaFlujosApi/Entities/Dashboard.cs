using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Entities
{
    public class Dashboard
    {
        public string idclient { get; set; }
        public string client { get; set; }
        public float projected { get; set; }
        public float real { get; set; }
        public float percentage { get; set; }
        public float difference { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string week { get; set; }
        public string export { get; set; }
    }

}
