using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/ReadOne?id=" + userid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Customer obj = JsonConvert.DeserializeObject<Customer>(kq);
                return View(obj);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase file, string fullname, string email) 
        {
            
            int userid = int.Parse(Session["UserID"].ToString());
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                ViewBag.ImagePath = "~/Content/Images/" + fileName;
            }

            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/UpdateProfile?id=" + userid + "&fullname=" +fullname+ "&avatarlink=" + "~/Content/Images/"+ Path.GetFileName(file.FileName) + "&email=" +email;
            int kq = restClient.UpdateData();
            if (kq == 1)
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return RedirectToAction("Index", "Customer");
            }
        }
        public ActionResult History()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Transection/ListAllByCustomer?customerid=" + userid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<History> obj = JsonConvert.DeserializeObject<List<History>>(kq);
                return View(obj);
            }
            else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }
        }
        public ActionResult ChangePassword(string password, string newpassword, string renewpassword)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/UpdatePassword?id=" + Session["UserID"] + "&password="+password+ "&npassword=" + newpassword + "&cnpassword=" + renewpassword;
            int kq = restClient.UpdateData();
            if (kq == 1)
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }
        }
    }
}