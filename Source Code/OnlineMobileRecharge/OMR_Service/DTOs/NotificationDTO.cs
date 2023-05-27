using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class NotificationDTO
    {
        public int NotificationID { get; set; }
        public string NotifyContent { get; set; }
        public DateTime Time { get; set; }
        public int CustomerID { get; set; }
    }
}