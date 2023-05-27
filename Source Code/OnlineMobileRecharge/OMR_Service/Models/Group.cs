using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public bool? Status { get; set; }   
        public List<FunctionGroup> FunctionGroup { get; set; }
        public List<GroupUser> GroupUser { get; set; }
    }
}