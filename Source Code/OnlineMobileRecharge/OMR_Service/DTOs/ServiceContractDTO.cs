using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class ServiceContractDTO
    {
        public int ServiceContractID { get; set; }
        public string Phone { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
    }
}