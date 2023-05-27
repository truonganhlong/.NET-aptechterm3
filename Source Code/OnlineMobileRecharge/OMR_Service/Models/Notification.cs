using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string NotifyContent { get; set; }
        public DateTime Time { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}