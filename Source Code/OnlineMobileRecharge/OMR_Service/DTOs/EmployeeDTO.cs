using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class EmployeeDTO
    {
        public int? EmployeeID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public string AvatarLink { get; set; }
        public int? ServiceProviderID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Status { get; set; }
        
    }
}