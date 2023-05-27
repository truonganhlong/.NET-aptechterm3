using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class TuneDTO
    {
        public int TuneID { get; set; }
        public string Link { get; set; }
        public bool? Status { get; set; }
    }
}