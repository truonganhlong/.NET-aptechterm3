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
    public class FunctionController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public FunctionController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<FunctionDTO> ReadAll()
        {
            try
            {
                var data = _db.Function.ToList();
                List<FunctionDTO> list = new List<FunctionDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<FunctionDTO>(item));
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
        [Route("api/Function/GetOne")]
        public FunctionDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Function.Find(id);
                if (data != null)
                {
                    return _mapper.Map<FunctionDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public bool Create(FunctionDTO dto)
        {
            try
            {
                if (_db.Function.Where(x => x.FunctionDescription == dto.FunctionDescription).ToList().Count > 0)
                {
                    return false;
                }
                else
                {
                    Function obj = new Function();
                    obj.FunctionDescription = dto.FunctionDescription;
                    _db.Function.Add(obj);
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
        public bool Update(int id, FunctionDTO dto)
        {
            try
            {
                var data = _db.Function.Find(id);
                if (data != null)
                {
                    data.FunctionDescription = dto.FunctionDescription;
                    _db.Function.Update(data);
                    _db.SaveChanges();
                    return true;
                }
                else
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
                var data = _db.Function.Find(id);
                if (data != null)
                {
                    _db.Function.Remove(data);
                    _db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
