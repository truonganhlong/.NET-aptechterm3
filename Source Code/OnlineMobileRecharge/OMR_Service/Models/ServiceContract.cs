using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class ServiceContract
    {
        public int ServiceContractID { get; set; }
        public string Phone { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public List<Transaction> Transaction { get;set; }
    }
}