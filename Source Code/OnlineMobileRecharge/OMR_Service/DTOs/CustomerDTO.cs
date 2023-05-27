using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class CustomerDTO
    {

        public int? CustomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public DateTime? Dob { get; set; }
        public string AvatarLink { get; set; }
        public int? TuneID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Disturb { get; set; }


    }
}