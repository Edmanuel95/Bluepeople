using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.grupokmm.flujos.Entities
{
    public class Bills
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startPayDate { get; set; }
        public string endPayDate { get; set; }
        public string idClient { get; set; }
        public string idChannel { get; set; }
        public string idSorter { get; set; }
        public string iduser { get; set; }

    }


    public class ViewInvoices
    {
        public Invoice[] Invoices { get; set; }
    }

    public class Invoice
    {
        public string idClient { get; set; }
        public string client { get; set; }
        public string bill { get; set; }
        public string balance { get; set; }
        public string amount { get; set; }
        public string balance_min { get; set; }
        public string channel { get; set; }

        public List<InvoiceClient> invoices { get; set; }



    }

    public class InvoiceClient
    {
        public string idBill { get; set; }
        public string idDigital { get; set; }
        public string idInvoice { get; set; }
        public string installation { get; set; }
        public string idClient { get; set; }
        public string client { get; set; }
        public string balance { get; set; }
        public string payment { get; set; }
        public string balanceMn { get; set; }

        public string expiration { get; set; }
        public string collection { get; set; }
        public string day { get; set; }
        public string type { get; set; }

    }

    public class Clients
    {
        public string idClient { get; set; }
        public string client { get; set; }
        
    }

    public class Channels   
    {
        public string idChannel { get; set; }
        public string channel { get; set; }

    }

    public class Sorters
    {
        public string idSorter { get; set; }
        public string sorter { get; set; }

    }

    public class payment
    {
        public string idclient  { get; set; }
        public string invoice { get; set; }
        public string digital { get; set; }
        public string installation { get; set; }
        public string amount { get; set; }
        public string amountMn { get; set; }
        public string money { get; set; }
        public string date { get; set; }

    }
    public class invoiceProjection
    {
        public string idInvoice { get; set; }
        public string installation { get; set; }

        public string idClient { get; set; }
        public string idDetailProjection { get; set; }

        public string idUser { get; set; }
 

    }

}
