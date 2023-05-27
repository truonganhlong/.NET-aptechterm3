using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult LoginNeedError()
        {
            return View();
        }
        public ActionResult SomethingWrong()
        {
            return View();
        }
        public ActionResult Permission()
        {
            return View();
        }
        public ActionResult WrongUsernameOrPassword()
        {
            return View();
        }
        public ActionResult NeedPhoneNumber()
        {
            return View();
        }
    }
}