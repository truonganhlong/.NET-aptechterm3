using Newtonsoft.Json;
using OMR_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace OMR_Client.Controllers
{
    public class TransactionController : Controller
    {
        public int servicecontractid;

        // GET: Transaction
        public ActionResult Index(int id, string phone)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LoginNeedError", "Error");
            } else
            {
                TempData["ServiceID"] = id;
                TempData["Phone"] = phone;
                ViewBag.Phone = phone;
                TempData["Phone"] = phone;
                Service service = new Service();
                List<Feedback> feedbacks = new List<Feedback>();
                List<Payment> payments = new List<Payment>();
                ViewBag.StringNotify = "You're registering service paid ";
                RestClient restClient = new RestClient();
                restClient.endPoint = "api/Service/GetOne?id=" + id;
                string kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    service = JsonConvert.DeserializeObject<Service>(kq);
                    TempData["ServiceName"] = service.ServiceName;
                    TempData["Price"] = service.Price;
                    if (service.Days != null)
                    {
                        TempData["Days"] = service.Days;
                    }
                    else
                    {
                        TempData["Days"] = null;
                    }
                }
                else
                {
                    return View();
                }
                restClient.endPoint = "api/Payment";
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    payments = JsonConvert.DeserializeObject<List<Payment>>(kq);

                }
                else
                {
                    return View();
                }
                restClient.endPoint = "api/Feedback/GetByService?serviceid=" + id;
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(kq);
                    foreach (Feedback item in feedbacks)
                    {
                        Customer customer = new Customer();
                        restClient.endPoint = "api/Customer/ReadOne?id=" + item.CustomerID;
                        kq = restClient.RestRequestAll();
                        if (kq != null)
                        {
                            customer = JsonConvert.DeserializeObject<Customer>(kq);
                            item.CustomerName = customer.Fullname;
                            item.CustomerImage = customer.AvatarLink;
                        }
                    }

                }
                else
                {
                    return View();
                }
                Tuple<Service, List<Feedback>, List<Payment>> tuple = new Tuple<Service, List<Feedback>, List<Payment>>(service, feedbacks, payments);
                return View(tuple);
            }
            
        }

        public ActionResult Transaction(string cardNumber, int MM, int YY, string cvv, string nameOnCard)
        {
            RestClient restClient = new RestClient();
            if (TempData["ServiceName"].ToString() == "Plan")
            {
                restClient.endPoint = "api/ServiceContract?phone=" + Session["Phone"].ToString() + "&customerid=" + Session["UserID"] + "&serviceid=" + TempData["ServiceID"];
                string result = restClient.InsertData();
                if (result != null)
                {
                    servicecontractid = int.Parse(JsonConvert.DeserializeObject<string>(result));
                }
            } else
            {
                if (TempData["Phone"] != null)
                {
                    restClient.endPoint = "api/ServiceContract?phone=" + TempData["Phone"].ToString() + "&customerid=" + Session["UserID"] + "&serviceid=" + TempData["ServiceID"];
                    string kq = restClient.InsertData();
                    if (kq != null)
                    {
                        servicecontractid = int.Parse(JsonConvert.DeserializeObject<string>(kq));
                    }

                }
                else
                {
                    return RedirectToAction("NeedPhoneNumber", "Error");
                }
            }
            
            restClient = new RestClient();
            Transaction transaction = new Transaction();
            if (cardNumber == null && cvv == null && nameOnCard == null)
            {
                transaction.PaymentID = 2;
            }
            else
            {
                transaction.PaymentID = 1;
                transaction.CardNumber = cardNumber;
                transaction.Expiry = MM.ToString() + "/" + YY.ToString();
                transaction.CVV = cvv;
                transaction.NameOnCard = nameOnCard;
            }
            transaction.ServiceContractID = servicecontractid;
            transaction.Price = (decimal)TempData["Price"];
            transaction.CustomerID = int.Parse(Session["UserID"].ToString());
            transaction.Days = (int?)TempData["Days"];
            restClient.endPoint = "api/Transaction";
            int ketqua = restClient.InsertData(transaction);
            if (ketqua == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }

        }
        public ActionResult PaypalTransaction()
        {
            RestClient restClient = new RestClient();
            if (TempData["ServiceName"].ToString() == "Plan")
            {
                restClient.endPoint = "api/ServiceContract?phone=" + Session["Phone"].ToString() + "&customerid=" + Session["UserID"] + "&serviceid=" + TempData["ServiceID"];
                string result = restClient.InsertData();
                if (result != null)
                {
                    servicecontractid = int.Parse(JsonConvert.DeserializeObject<string>(result));
                }
            }
            else
            {
                if (TempData["Phone"] != null)
                {
                    restClient.endPoint = "api/ServiceContract?phone=" + TempData["Phone"].ToString() + "&customerid=" + Session["UserID"] + "&serviceid=" + TempData["ServiceID"];
                    string result = restClient.InsertData();
                    if (result != null)
                    {
                        servicecontractid = int.Parse(JsonConvert.DeserializeObject<string>(result));
                    }

                }
                else
                {
                    return RedirectToAction("NeedPhoneNumber", "Error");
                }
            }
            
            restClient = new RestClient();
            Transaction transaction = new Transaction();
            transaction.PaymentID = 2;
            transaction.ServiceContractID = servicecontractid;
            transaction.Price = (decimal)TempData["Price"];
            transaction.CustomerID = int.Parse(Session["UserID"].ToString());
            transaction.Days = (int?)TempData["Days"];
            restClient.endPoint = "api/Transaction";
            int ketqua = restClient.InsertData(transaction);
            if (ketqua == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SendFeedback(string feedback)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Feedback?customerid=" + Session["UserID"]+"&serviceid=" + TempData["ServiceID"]+"&contentfb=" +feedback;
            string kq = restClient.InsertData();
            if (kq != null)
            {
                return RedirectToAction("Index", "Transaction", new {id = TempData["ServiceID"], phone = TempData["Phone"] });
            } else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }
        }
    }
}