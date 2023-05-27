using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class ServiceProvider
    {
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public string Link { get; set; }
        public bool? Status { get; set; }
        public List<Service> Service { get; set; }
        public List<Employee> Employee { get; set; }
    }
}