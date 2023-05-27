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
    public class NotificationController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;

        public NotificationController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<NotificationDTO> ReadAll(int customerid)
        {
            try
            {
                var data = _db.Notification.Where(x => x.CustomerID == customerid).ToList();
                List<NotificationDTO> list = new List<NotificationDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<NotificationDTO>(item));
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
        [Route("api/Notification/GetOne")]
        public NotificationDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Notification.Find(id);
                if (data != null)
                {
                    return _mapper.Map<NotificationDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Create(NotificationDTO dto)
        {
            try
            {
                Notification obj = new Notification();
                obj.NotifyContent = dto.NotifyContent;
                obj.Time = DateTime.Now;
                obj.CustomerID = dto.CustomerID;
                _db.Notification.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
