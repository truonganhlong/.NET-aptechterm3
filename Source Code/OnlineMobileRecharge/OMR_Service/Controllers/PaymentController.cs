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
    public class PaymentController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;

        public PaymentController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<PaymentDTO> ReadAll() {
            try
            {
                var data = _db.Payment.ToList();
                List<PaymentDTO> list = new List<PaymentDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<PaymentDTO>(item));
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
        [Route("api/Payment/GetOne")]
        public PaymentDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Payment.Find(id);
                if (data != null)
                {
                    return _mapper.Map<PaymentDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public bool Create(PaymentDTO dto)
        {
            try
            {
                if(_db.Payment.Where(x => x.PaymentType == dto.PaymentType).ToList().Count > 0)
                {
                    return false;
                } else
                {
                    Payment obj = new Payment();
                    obj.PaymentType = dto.PaymentType;
                    _db.Payment.Add(obj);
                    _db.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpPut]
        public bool Update(int id,PaymentDTO dto)
        {
            try
            {
                var data = _db.Payment.Find(id);
                if (data != null)
                {
                    data.PaymentType = dto.PaymentType;
                    _db.Payment.Update(data);
                    _db.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                var data = _db.Payment.Find(id);
                if(data != null)
                {
                    _db.Payment.Remove(data);
                    _db.SaveChanges();
                    return true;
                } else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
