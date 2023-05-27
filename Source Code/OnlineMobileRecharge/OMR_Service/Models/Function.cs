using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Function
    {
        public int FunctionID { get; set; }
        public string FunctionDescription { get; set; }
        public bool? Status { get; set; }
        public List<UserFunction> UserFunction { get; set; }
        public List<FunctionGroup> FunctionGroup { get; set; }
    }
}