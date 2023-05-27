using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}