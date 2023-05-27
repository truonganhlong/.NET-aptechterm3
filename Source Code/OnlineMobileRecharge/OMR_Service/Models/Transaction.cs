using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int ServiceContractID { get; set; }
        public int? CustomerID { get; set; }
        public int PaymentID { get; set; }
        public decimal Price { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }
        public string NameOnCard { get; set; }
        public DateTime TransferTime { get; set; }
        public int? Days { get; set; }
        public DateTime? EndTime { get; set; }
        public ServiceContract ServiceContract{ get; set; }        
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}