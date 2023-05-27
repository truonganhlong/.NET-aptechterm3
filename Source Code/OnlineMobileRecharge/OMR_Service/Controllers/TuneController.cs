using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using OMR_Service.DTOs;
using OMR_Service.EF;
using OMR_Service.Models;

namespace OMR_Service.Controllers
{
    public class TuneController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;

        public TuneController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<TuneDTO> ReadAll()
        {
            try
            {
                var data = _db.Tune.ToList();
                List<TuneDTO> list = new List<TuneDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<TuneDTO>(item));
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
        [Route("api/Tune/GetListForUser")]
        public TuneDTO GetListForUser(int id)
        {
            try
            {
                var data = _db.Tune.Find(id);
                if (data != null)
                {
                    return _mapper.Map<TuneDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Create(TuneDTO dto)
        {
            try
            {
                Tune obj = new Tune();
                if (_db.Tune.Where(x => x.Link == dto.Link) != null)
                {
                    obj.Link = dto.Link;
                    obj.Status = true;
                    _db.Tune.Add(obj);
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
