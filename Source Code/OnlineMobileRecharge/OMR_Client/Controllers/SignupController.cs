using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string phone, string password, string email, string fullname)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/Register?phone=" + phone + "&password=" + password + "&email=" + email +"&fullname=" + fullname;
            string kq = restClient.InsertData();
            if (kq != null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}