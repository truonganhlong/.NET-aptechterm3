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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Transaction/Count";
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                ViewBag.Count = JsonConvert.DeserializeObject<int>(kq);
            }
            restClient.endPoint = "api/Transaction/Revenue";
            kq = restClient.RestRequestAll();
            if (kq != null)
            {
                ViewBag.Revenue = JsonConvert.DeserializeObject<decimal>(kq);
            }
            restClient.endPoint = "api/Customer/GetThisWeek";
            kq = restClient.RestRequestAll();
            if (kq != null)
            {
                ViewBag.CustomerCount = JsonConvert.DeserializeObject<int>(kq);
            }
            restClient.endPoint = "api/Employee/ReadOne?id=" + int.Parse(Session["UserID"].ToString());
            kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(kq);
                return View(employee);
            }
            else { return View(); }
        }

        public ActionResult Customer()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/ReadAll";
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<Customer> customer = JsonConvert.DeserializeObject<List<Customer>>(kq);
                return View(customer);
            }
            else { return View(); }
        }
        public ActionResult DetailCustomer(int customerid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Customer/ReadOne?id=" + customerid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Customer customer = JsonConvert.DeserializeObject<Customer>(kq);
                return View(customer);
            }
            else { return View(); }
        }
        public ActionResult Transaction()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/CheckAdmin?userid=" + Session["UserID"];
            string kq = restClient.InsertData();
            if (kq != null)
            {
                restClient.endPoint = "api/Transaction/GetAllForAdmin";
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    List<History> transaction = JsonConvert.DeserializeObject<List<History>>(kq);
                    return View(transaction);
                }
                else { return RedirectToAction("SomethingWrong", "Error"); }
            }
            else
            {
                restClient.endPoint = "api/User/CheckEmp?userid=" + Session["UserID"];
                kq = restClient.InsertData();
                if (kq != null)
                {
                    int serviceproviderid = JsonConvert.DeserializeObject<int>(kq);
                    TempData["serviceproviderid"] = serviceproviderid;
                    restClient.endPoint = "api/Transaction/GetAllForEmp?serviceproviderid=" + serviceproviderid;
                    kq = restClient.RestRequestAll();
                    if (kq != null)
                    {
                        List<History> transaction = JsonConvert.DeserializeObject<List<History>>(kq);
                        return View(transaction);
                    }
                    else { return RedirectToAction("SomethingWrong", "Error"); }
                }
                else
                {
                    return RedirectToAction("Permission", "Error");
                }
            }
        }
        public ActionResult DetailTransaction(int transactionid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Transaction/GetOneForAdmin?transactionid=" + transactionid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                History transaction = JsonConvert.DeserializeObject<History>(kq);
                return View(transaction);
            }
            else { return View(); }
        }

        public ActionResult Employee()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/CheckAdmin?userid=" + Session["UserID"];
            string kq = restClient.InsertData();
            if (kq != null)
            {
                restClient.endPoint = "api/Employee/ReadAll";
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(kq);
                    foreach (Employee employee in employees)
                    {
                        if (employee.ServiceProviderID == 1)
                        {
                            employee.ServiceProviderName = "Viettel";
                        } else if (employee.ServiceProviderID == 2)
                        {
                            employee.ServiceProviderName = "Vinaphone";
                        } else if (employee.ServiceProviderID == 3)
                        {
                            employee.ServiceProviderName = "Mobiphone";
                        } else
                        {
                            employee.ServiceProviderName = null;
                        }
                    }
                    return View(employees);
                }
                else { return RedirectToAction("SomethingWrong", "Error"); }
            } else { return RedirectToAction("Permission", "Error"); }

        }
        public ActionResult CreateEmployee()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/ServiceProvider";
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<ServiceProvider> list = JsonConvert.DeserializeObject<List<ServiceProvider>>(kq);
                ViewBag.ServiceProvider = new SelectList(list, "ServiceProviderID", "ServiceProviderName");
                return View();
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        [HttpPost]
        public ActionResult CreateEmployee(FormCollection collection)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Employee/Register?phone=" + collection["Phone"] + "&serviceproviderid=" + collection["ServiceProviderID"] + "&email=" + collection["Email"] + "&fullname=" + collection["Fullname"];
            string kq = restClient.InsertData();
            if (kq != null)
            {
                return RedirectToAction("Employee", "Employee");
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        public ActionResult DetailEmployee(int employeeid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Employee/ReadOne?id=" + employeeid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(kq);
                if (employee.ServiceProviderID == 1)
                {
                    employee.ServiceProviderName = "Viettel";
                }
                else if (employee.ServiceProviderID == 2)
                {
                    employee.ServiceProviderName = "Vinaphone";
                }
                else if (employee.ServiceProviderID == 3)
                {
                    employee.ServiceProviderName = "Mobiphone";
                }
                else
                {
                    employee.ServiceProviderName = null;
                }
                return View(employee);
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        public ActionResult DeleteEmployee(int employeeid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Employee/ReadOne?id=" + employeeid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(kq);
                if (employee.ServiceProviderID == 1)
                {
                    employee.ServiceProviderName = "Viettel";
                }
                else if (employee.ServiceProviderID == 2)
                {
                    employee.ServiceProviderName = "Vinaphone";
                }
                else if (employee.ServiceProviderID == 3)
                {
                    employee.ServiceProviderName = "Mobiphone";
                }
                else
                {
                    employee.ServiceProviderName = null;
                }
                return View(employee);
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        [HttpPost]
        public ActionResult DeleteEmployee(int employeeid, FormCollection collection)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Employee/Delete?id=" + employeeid;
            int kq = restClient.DeleteData();
            if (kq == 1)
            {
                return RedirectToAction("Employee", "Employee");
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        public ActionResult Register()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/CheckAdmin?userid=" + Session["UserID"];
            string kq = restClient.InsertData();
            if (kq != null)
            {
                restClient.endPoint = "api/Employee/ReadAll";
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(kq);
                    User user = new User();
                    Tuple<User, List<Employee>> tuple = new Tuple<User, List<Employee>>(user, employees);
                    return View(tuple);
                }
                else { return RedirectToAction("SomethingWrong", "Error"); }
            }
            else { return RedirectToAction("Permission", "Error"); }
        }
        public ActionResult RegisterNew(string username, string password, int employee)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/Register?username=" + username + "&password=" + password + "&employeeid=" + employee;
            string kq = restClient.InsertData();
            if (kq != null)
            {
                return RedirectToAction("Index", "Employee");
            } else
            {
                return RedirectToAction("SomethingWrong", "Error");
            }
        }
        public ActionResult Signout()
        {
            Session.Remove("UserID");
            Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Service()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/CheckAdmin?userid=" + Session["UserID"];
            string kq = restClient.InsertData();
            if (kq != null)
            {
                restClient.endPoint = "api/Service";
                kq = restClient.RestRequestAll();
                if (kq != null)
                {
                    List<Service> services = JsonConvert.DeserializeObject<List<Service>>(kq);
                    foreach (Service service in services)
                    {
                        if (service.ServiceProviderID == 1)
                        {
                            service.ServiceProviderName = "Viettel";
                        }
                        else if (service.ServiceProviderID == 2)
                        {
                            service.ServiceProviderName = "Vinaphone";
                        }
                        else if (service.ServiceProviderID == 3)
                        {
                            service.ServiceProviderName = "Mobiphone";
                        }
                        else
                        {
                            service.ServiceProviderName = null;
                        }
                    }
                    return View(services);
                }
                else
                {
                    return RedirectToAction("SomethingWrong", "Error");
                }
            }
            else
            {
                restClient.endPoint = "api/User/CheckEmp?userid=" + Session["UserID"];
                kq = restClient.InsertData();
                if (kq != null)
                {
                    int serviceproviderid = JsonConvert.DeserializeObject<int>(kq);
                    TempData["serviceproviderid"] = serviceproviderid;
                    restClient.endPoint = "api/Service/GetByCategory?serviceproviderid=" +serviceproviderid;
                    kq = restClient.RestRequestAll();
                    if (kq != null)
                    {
                        List<Service> services = JsonConvert.DeserializeObject<List<Service>>(kq);
                        foreach (Service service in services)
                        {
                            if (service.ServiceProviderID == 1)
                            {
                                service.ServiceProviderName = "Viettel";
                            }
                            else if (service.ServiceProviderID == 2)
                            {
                                service.ServiceProviderName = "Vinaphone";
                            }
                            else if (service.ServiceProviderID == 3)
                            {
                                service.ServiceProviderName = "Mobiphone";
                            }
                            else
                            {
                                service.ServiceProviderName = null;
                            }
                        }
                        return View(services);
                    }
                    else
                    {
                        return RedirectToAction("SomethingWrong", "Error");
                    }
                }
                else
                {
                    return RedirectToAction("Permission", "Error");
                }
            
            }
        }

        public ActionResult CreateService()
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/ServiceProvider";
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                List<ServiceProvider> list = JsonConvert.DeserializeObject<List<ServiceProvider>>(kq);
                ViewBag.listServiceProvider = new SelectList(list, "ServiceProviderID", "ServiceProviderName");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(FormCollection collection)
        {
            if (TempData["serviceproviderid"] == null)
            {
                RestClient restClient = new RestClient();
                
                restClient.endPoint = "api/Service?serviceproviderid=" + collection["ServiceProviderID"] + "&servicename=" + collection["ServiceName"] + "&servicedescription=" + collection["ServiceDescription"] + "&price=" + collection["Price"] + "&days=" + collection["Days"];
                string kq = restClient.InsertData();
                if (kq != null)
                {
                    return RedirectToAction("Service", "Employee");
                }
                else { return RedirectToAction("SomethingWrong", "Error"); }
            } else
            {
                RestClient restClient = new RestClient();
                restClient.endPoint = "api/Service?serviceproviderid=" + int.Parse(TempData["serviceproviderid"].ToString()) + "&servicename=" + collection["ServiceName"] + "&servicedescription=" + collection["ServiceDescription"] + "&price=" + collection["Price"] + "&days=" + collection["Days"];
                string kq = restClient.InsertData();
                if (kq != null)
                {
                    return RedirectToAction("Service", "Employee");
                }
                else { return RedirectToAction("SomethingWrong", "Error"); }
            }
            
        }
        public ActionResult DetailService(int serviceid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/GetOne?id=" + serviceid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Service service = JsonConvert.DeserializeObject<Service>(kq);
                if (service.ServiceProviderID == 1)
                {
                    service.ServiceProviderName = "Viettel";
                }
                else if (service.ServiceProviderID == 2)
                {
                    service.ServiceProviderName = "Vinaphone";
                }
                else if (service.ServiceProviderID == 3)
                {
                    service.ServiceProviderName = "Mobiphone";
                }
                else
                {
                    service.ServiceProviderName = null;
                }
                return View(service);
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }

        public ActionResult DeleteService(int serviceid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/GetOne?id=" + serviceid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Service service = JsonConvert.DeserializeObject<Service>(kq);
                if (service.ServiceProviderID == 1)
                {
                    service.ServiceProviderName = "Viettel";
                }
                else if (service.ServiceProviderID == 2)
                {
                    service.ServiceProviderName = "Vinaphone";
                }
                else if (service.ServiceProviderID == 3)
                {
                    service.ServiceProviderName = "Mobiphone";
                }
                else
                {
                    service.ServiceProviderName = null;
                }
                return View(service);
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        [HttpPost]
        public ActionResult DeleteService(int employeeid, FormCollection collection)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service?id" + employeeid;
            int kq = restClient.DeleteData();
            if (kq == 1)
            {
                return RedirectToAction("Service", "Service");
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        public ActionResult EditService(int serviceid)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/GetOne?id=" + serviceid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Service service = JsonConvert.DeserializeObject<Service>(kq);
                if (service.ServiceProviderID == 1)
                {
                    service.ServiceProviderName = "Viettel";
                }
                else if (service.ServiceProviderID == 2)
                {
                    service.ServiceProviderName = "Vinaphone";
                }
                else if (service.ServiceProviderID == 3)
                {
                    service.ServiceProviderName = "Mobiphone";
                }
                else
                {
                    service.ServiceProviderName = null;
                }
                return View(service);
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }
        [HttpPost]
        public ActionResult EditService(Service obj)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Service/Update";
            int kq = restClient.UpdateData(obj);
            if (kq == 1)
            {
                return RedirectToAction("Service", "Employee");
            }
            else { return RedirectToAction("SomethingWrong", "Error"); }
        }

        public ActionResult EmpProfile()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/Employee/GetByUserID?userid=" + userid;
            string kq = restClient.RestRequestAll();
            if (kq != null)
            {
                Employee obj = JsonConvert.DeserializeObject<Employee>(kq);
                return View(obj);
            }
            else
            {
                return View();
            }
        }
        public ActionResult ChangePassword(string password, string newpassword, string renewpassword)
        {
            RestClient restClient = new RestClient();
            restClient.endPoint = "api/User/UpdatePassword?id=" + Session["UserID"] + "&password=" + password + "&npassword=" + newpassword + "&cnpassword=" + renewpassword;
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
            restClient.endPoint = "api/Employee/UpdateProfile?id=" + userid + "&fullname=" + fullname + "&avatarlink=" + "~/Content/Images/" + Path.GetFileName(file.FileName) + "&email=" + email;
            int kq = restClient.UpdateData();
            if (kq == 1)
            {
                return RedirectToAction("EmpProfile", "Employee");
            }
            else
            {
                return RedirectToAction("EmpProfile", "Employee");
            }
        }
    }
}