using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/Login?phone=" + phone + "&password=" + password;
            string kq = restClient.InsertData();
            if (kq != null)
            {
                Session["UserID"] = kq;
                Session["Phone"] = phone;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("WrongUsernameOrPassword", "Error");
            }
        }
        public ActionResult EmpLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmpLogin(string username, string password)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/Login?username=" + username + "&password=" + password;
            string kq = restClient.InsertData();
            if (kq != null)
            {
                Session["UserID"] = kq;
                Session["UserName"] = username;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return RedirectToAction("WrongUsernameOrPassword", "Error");
            }
        }
    }
}