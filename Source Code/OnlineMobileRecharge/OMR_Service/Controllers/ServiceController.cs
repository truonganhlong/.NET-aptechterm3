using AutoMapper;
using OMR_Service.DTOs;
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
    public class ServiceController : ApiController
    {

        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public ServiceController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<ServiceDTO> ReadAll()
        {
            try
            {
                var data = _db.Service.ToList();
                List<ServiceDTO> list = new List<ServiceDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<ServiceDTO>(item));
                    }
                    return list;
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Service/GetOne")]
        public ServiceDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Service.Find(id);
                if (data != null)
                {
                    return _mapper.Map<ServiceDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Service/GetForUser")]
        public List<ServiceDTO> ReadForUser(int serviceproviderid, string servicename)
        {
            try
            {
                var data = _db.Service.Where(x => x.Status ==true && x.ServiceProviderID == serviceproviderid && x.ServiceName == servicename).ToList();
                if (data != null)
                {
                    return _mapper.Map<List<ServiceDTO>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Service/GetByCategory")]
        public List<ServiceDTO> ReadForCategory(int serviceproviderid)
        {
            try
            {
                var data = _db.Service.Where(x => x.Status == true && x.ServiceProviderID == serviceproviderid).ToList();
                if (data != null)
                {
                    return _mapper.Map<List<ServiceDTO>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public bool Create(int serviceproviderid, string servicename, string servicedescription, decimal price, int? days)
        {
            try
            {
                Service obj = new Service();
                if (_db.Service.Where(x => x.ServiceName == servicename) != null)
                {
                    obj.ServiceName = servicename;
                    obj.ServiceDescription = servicedescription;
                    obj.Price = price;
                    if(days != null)
                    {
                        obj.Days = days;
                    } else { obj.Days = null; }
                    obj.ServiceProviderID = serviceproviderid;
                    obj.Status = true;
                    _db.Service.Add(obj);
                    _db.SaveChanges();
                    return true;

                }
                else { return false; }
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpPut]
        [Route("api/Service/Update")]
        public bool Update(ServiceDTO dto)
        {
            try
            {
                Service obj = _db.Service.Find(dto.ServiceID);
                if (obj != null)
                {
                    obj.ServiceName = dto.ServiceName ?? obj.ServiceName;
                    obj.ServiceDescription = dto.ServiceDescription ?? obj.ServiceDescription;
                    obj.Price = dto.Price ?? obj.Price;
                    obj.Days = dto.Days ?? obj.Days;
                    _db.Service.Update(obj);
                    _db.SaveChanges();
                    return true;
                }
                else { return false; }

            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpPut]
        [Route("api/Service/UpdateStatus")]
        public bool UpdateStatus(int id)
        {
            try
            {
                Service obj = _db.Service.Find(id);
                if (obj != null)
                {
                    obj.Status = !obj.Status;
                    _db.Service.Update(obj);
                    _db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Service obj = _db.Service.Find(id);
                if (obj != null)
                {
                    _db.Remove(obj);
                    _db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public bool CheckAdmin(int employeeid, int serviceproviderid)
        //{
        //    try
        //    {
        //        if (serviceproviderid == _db.Employee.Find(employeeid).ServiceProviderID)
        //        {
        //            return true;
        //        }
        //        else {
        //            int userid = _db.Employee.Find(employeeid).UserID;
        //            string userDescription = _db.Users.Find(userid).UserDescription;
        //            if (userDescription == "Admin")
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
       
    }
}
