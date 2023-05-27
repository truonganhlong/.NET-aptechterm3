using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class FunctionGroup
    {
        public int GroupID { get; set; }
        public int FunctionID { get; set; }
        public Group Group { get; set; }
        public Function Function { get; set; }
    }
}