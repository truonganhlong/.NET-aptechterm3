using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class HistoryDTO
    {
        public int TransactionID { get; set; }
        public string ServiceDescription { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public DateTime TransferTime { get; set; }
        public int? Days { get; set; }
        public DateTime? EndTime { get; set; }
        public string PaymentType { get; set; }
    }
}