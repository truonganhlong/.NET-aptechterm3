﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Client.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmployeeID { get; set; }
        public bool? Status { get; set; }
    }
}