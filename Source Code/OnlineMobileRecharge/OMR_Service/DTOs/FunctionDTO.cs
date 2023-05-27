using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class FunctionDTO
    {
        public int? FunctionID { get; set; }
        public string FunctionDescription { get; set; }
        public bool? Status { get; set; }
    }
}