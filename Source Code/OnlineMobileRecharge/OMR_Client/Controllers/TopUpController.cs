using Newtonsoft.Json;
using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class TopUpController : Controller
    {
        public int serviceProviderID;
        // GET: TopUp
        public ActionResult Index(string phone)
        {
            ViewBag.Phone = phone;
            var viettelregex = new Regex(@"\b(035|036|037|032|033|034|038|039|096|097|098|086)\S*\b");
            var vinaregex = new Regex(@"\b(088|091|094|083|084|085|081|082)\S*\b");
            var mobiregex = new Regex(@"\b(089|090|093|070|079|077|076|078)\S*\b");
            if (viettelregex.IsMatch(phone))
            {
                ViewBag.Logo = Url.Content("~/Content/Images/viettel-logo.jpg");
                serviceProviderID= 1;
            }
            else if (vinaregex.IsMatch(phone))
            {
                ViewBag.Logo = Url.Content("~/Content/Images/vinaphone-logo.png");
                serviceProviderID= 2;
            }
            else if (mobiregex.IsMatch(phone))
            {
                ViewBag.Logo = Url.Content("~/Content/Images/mobiphone-logo.jpg");
                serviceProviderID= 3;
            }
            else
            {
                ViewBag.Logo = null;
            }
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/GetForUser?serviceproviderid=" + serviceProviderID+"&servicename=TopUp";
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<Service> list = JsonConvert.DeserializeObject<List<Service>>(kq);
                return View(list);
            }
            else
            {
                return View();
            }
        }
    }
}