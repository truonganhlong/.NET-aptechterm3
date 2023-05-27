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
    public class FeedbackController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public FeedbackController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<FeedbackDTO> ReadAll()
        {
            try
            {
                var data = _db.Feedback.ToList();
                List<FeedbackDTO> list = new List<FeedbackDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<FeedbackDTO>(item));
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
        [Route("api/Feedback/GetOne")]
        public FeedbackDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Feedback.Find(id);
                if (data != null)
                {
                    return _mapper.Map<FeedbackDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Feedback/GetByService")]
        public List<FeedbackDTO> ReadByService(int serviceid)
        {
            try
            {
                var data = _db.Feedback.Where(x => x.ServiceID == serviceid).ToList();
                if (data != null)
                {
                    return _mapper.Map<List<FeedbackDTO>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public bool Create(int customerid, int serviceid, string contentfb)
        {
            try
            {
                Feedback obj = new Feedback();
                obj.CustomerID = customerid;
                obj.ServiceID = serviceid;
                obj.ContentFB = contentfb;
                obj.CreatedAt = DateTime.Now;
                obj.Status = true;
                _db.Feedback.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpPut]
        [Route("api/Feedback/Update")]
        public bool Update(int id, FeedbackDTO dto)
        {
            try
            {
                Feedback obj = _db.Feedback.Find(id);
                if (obj != null)
                {

                    if (dto.ContentFB != null)
                    {
                        obj.ContentFB = dto.ContentFB;
                    }
                    if (dto.StarRate != null)
                    {
                        obj.StarRate = (int)dto.StarRate;
                    }
                    obj.UpdatedAt = DateTime.Now;
                    _db.Feedback.Update(obj);
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
        [Route("api/Feedback/UpdateStatus")]
        public bool UpdateStatus(int id)
        {
            try
            {
                Feedback obj = _db.Feedback.Find(id);
                if (obj != null)
                {
                    obj.Status = !obj.Status;
                    _db.Feedback.Update(obj);
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
                Feedback obj = _db.Feedback.Find(id);
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
    }
}
