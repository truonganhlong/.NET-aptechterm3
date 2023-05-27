using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class FeedbackDTO
    {
        public int FeedbackID { get; set; }
        public int CustomerID { get; set; }
        public int? ServiceID { get; set; }
        public string ContentFB { get; set; }
        public int? StarRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Status { get; set; }
    }
}