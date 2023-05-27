using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Models
{
    public class GroupUser
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public User User { get; set; }
        public Group Group { get; set;}
    }
}