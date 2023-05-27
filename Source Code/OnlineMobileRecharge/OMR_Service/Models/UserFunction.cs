using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class UserFunction
    {
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        public User User { get; set; }
        public Function Function { get; set; }
    }
}