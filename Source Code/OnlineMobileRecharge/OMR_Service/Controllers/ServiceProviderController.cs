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
    public class ServiceProviderController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public ServiceProviderController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<ServiceProviderDTO> ReadAll()
        {
            try
            {
                var data = _db.ServiceProvider.ToList();
                List<ServiceProviderDTO> list = new List<ServiceProviderDTO>();
                if(data.Count > 0)
                {
                    foreach(var item in data)
                    {
                        list.Add(_mapper.Map<ServiceProviderDTO>(item));
                    }
                    return list;
                } else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/ServiceProvider/GetOne")]
        public ServiceProviderDTO ReadOne(int id) {
            try
            {
                var data = _db.ServiceProvider.Find(id);
                if(data != null)
                {
                    return _mapper.Map<ServiceProviderDTO>(data);
                } else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/ServiceProvider/GetByEmployee")]
        public ServiceProviderDTO ReadByEmployee(int employeeid)
        {
            try
            {
                int serviceproviderid = (int)_db.Employee.Find(employeeid).ServiceProviderID;
                var data = _db.ServiceProvider.Find(serviceproviderid);
                if (data != null)
                {
                    return _mapper.Map<ServiceProviderDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public bool Create(int employeeid, ServiceProviderDTO dto)
        {
            try
            {
                ServiceProvider obj = new ServiceProvider();
                if(_db.ServiceProvider.Where(x => x.ServiceProviderName == dto.ServiceProviderName) != null)
                {
                    obj.ServiceProviderName = dto.ServiceProviderName;
                    obj.Link = dto.Link;
                    obj.Status = true;
                    _db.ServiceProvider.Add(obj);
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
        [Route("api/ServiceProvider/Update")]
        public bool Update(int id, int employeeid, ServiceProviderDTO dto)
        {
            try
            {
                ServiceProvider obj =_db.ServiceProvider.Find(id);
                if(obj != null)
                {
                    if (dto.ServiceProviderName != null)
                    {
                        obj.ServiceProviderName = dto.ServiceProviderName;
                    }
                    if (dto.Link != null)
                    {
                        obj.Link = dto.Link;
                    }
                    _db.ServiceProvider.Update(obj);
                    _db.SaveChanges();
                    return true;

                } else { return false; }
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpPut]
        [Route("api/ServiceProvider/UpdateStatus")]
        public bool UpdateStatus(int id, int employeeid)
        {
            try
            {
                ServiceProvider obj = _db.ServiceProvider.Find(id);  
                if(obj != null)
                {
                    obj.Status = !obj.Status;
                    _db.ServiceProvider.Update(obj);
                    _db.SaveChanges();
                    return true;
                } else { return false; }
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpDelete]
        public bool Delete(int id, int employeeid) {
            try
            {
                ServiceProvider obj = _db.ServiceProvider.Find(id);
                if(obj != null)
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
        //public bool CheckAdmin(int employeeid)
        //{
        //    try
        //    {
        //        int userid = _db.Employee.Find(employeeid).UserID;
        //        string userDescription = _db.Users.Find(userid).UserDescription;
        //        if(userDescription == "Admin") {
        //            return true;
        //        } else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
    }
}
