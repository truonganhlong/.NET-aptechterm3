using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.DTOs
{
    public class GroupDTO
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public bool? Status { get; set; }
    }
}