using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Tune
    {
        public int TuneID { get; set; }
        public string Link { get; set; }
        public bool? Status { get; set; }
        public List<Customer> Customer { get; set; }
    }
}