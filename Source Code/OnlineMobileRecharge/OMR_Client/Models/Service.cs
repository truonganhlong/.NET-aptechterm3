using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Client.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal? Price { get; set; }
        public int? Days { get; set; }
        public bool? Status { get; set; }
        public string ServiceProviderName { get; set; }
    }
}