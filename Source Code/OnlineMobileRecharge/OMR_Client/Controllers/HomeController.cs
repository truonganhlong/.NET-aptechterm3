using Newtonsoft.Json;
using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace OMR_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(string phone)
        {
            ViewBag.Phone = phone;
            return RedirectToAction("Index", "TopUp", new { phone = phone });
        }
        public ActionResult Logout()
        {
            Session.Remove("UserID");
            Session.Remove("Phone");
            return RedirectToAction("Index","Home");
        }
        public ActionResult SendTopUp()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult ServiceProvider(int id)
        {
            if(id ==1)
            {
                ViewBag.Logo = Url.Content("~/Content/Images/viettel-logo.jpg");
            } else if(id ==2)
            {
                ViewBag.Logo = Url.Content("~/Content/Images/vinaphone-logo.png");
            } else if(id ==3) {
                ViewBag.Logo = Url.Content("~/Content/Images/mobiphone-logo.jpg");
            } else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }
            
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/GetByCategory?serviceproviderid=" +id;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<Service> services = JsonConvert.DeserializeObject<List<Service>>(kq);
                return View(services);
            }
            else { return View(); }
        }
    }
}