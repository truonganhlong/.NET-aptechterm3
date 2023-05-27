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
    public class GroupController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public GroupController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public List<GroupDTO> ReadAll()
        {
            try
            {
                var data = _db.Group.ToList();
                List<GroupDTO> list = new List<GroupDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<GroupDTO>(item));
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
        [Route("api/Group/GetOne")]
        public GroupDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Group.Find(id);
                if (data != null)
                {
                    return _mapper.Map<GroupDTO>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public bool Create(GroupDTO dto)
        {
            try
            {
                if (_db.Group.Where(x => x.GroupName == dto.GroupName).ToList().Count > 0)
                {
                    return false;
                }
                else
                {
                    Group obj = new Group();
                    obj.GroupName = dto.GroupName;
                    _db.Group.Add(obj);
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
        public bool Update(int id, GroupDTO dto)
        {
            try
            {
                var data = _db.Group.Find(id);
                if (data != null)
                {
                    data.GroupName = dto.GroupName;
                    _db.Group.Update(data);
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
                var data = _db.Group.Find(id);
                if (data != null)
                {
                    _db.Group.Remove(data);
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
