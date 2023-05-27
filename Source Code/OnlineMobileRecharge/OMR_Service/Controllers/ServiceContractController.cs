using AutoMapper;
using OMR_Service.EF;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMR_Service.Controllers
{
    public class ServiceContractController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public ServiceContractController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpPost]
        public int Create(string phone, int customerid, int serviceid)
        {
            try
            {
                ServiceContract obj = new ServiceContract();
                obj.Phone = phone;
                obj.CustomerID = customerid;
                obj.ServiceID = serviceid;
                _db.ServiceContract.Add(obj);
                _db.SaveChanges();
                return obj.ServiceContractID;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
