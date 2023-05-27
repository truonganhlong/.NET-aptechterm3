using AutoMapper;
using OMR_Service.DTOs;
using OMR_Service.EF;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace OMR_Service.Controllers
{
    public class EmployeeController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public EmployeeController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        
        [HttpPost]
        [Route("api/Employee/Register")]
        public bool Register(string phone, int? serviceproviderid, string email, string fullname)
            {
            try
            {
                var data = _db.Employee.Where(x => x.Phone == phone).ToList();
                if (data.Count > 0)
                {
                    return false;
                }
                else
                {
                    Employee employee = new Employee();
                    employee.Email= email;
                    employee.Fullname = fullname;
                    employee.Phone = phone;
                    employee.CreatedAt = DateTime.Now;
                    employee.Status = true;
                    employee.ServiceProviderID = serviceproviderid;
                    _db.Employee.Add(employee);
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        
        [HttpGet]
        [Route("api/Employee/ReadAll")]
        public List<EmployeeDTO> ReadAll()
        {
            try
            {
                var data = _db.Employee.ToList();
                if (data.Count > 0)
                {
                    return _mapper.Map<List<EmployeeDTO>>(data);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Employee/ReadOne")]
        public EmployeeDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Employee.Find(id);
                if (data != null)
                {
                    return _mapper.Map<EmployeeDTO>(data);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Employee/GetByUserID")]
        public EmployeeDTO GetByUserID(int userid)
        {
            try
            {
                int employeeid = _db.Users.Find(userid).EmployeeID;
                var data = _db.Employee.Find(employeeid);
                if (data != null)
                {
                    return _mapper.Map<EmployeeDTO>(data);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("api/Employee/Delete")]
        public bool Delete(int id) {
            try
            {
                var data = _db.Employee.Find(id);
                if( data == null)
                {
                    return false;
                } else
                {
                    _db.Employee.Remove(data);
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("api/Employee/UpdateProfile")]
        public bool UpdateProfile(int id, string email, string fullname, string avatarlink)
        {
            try
            {
                int employeeid = _db.Users.Find(id).EmployeeID;
                var data = _db.Employee.Find(employeeid);

                if (data != null)
                {
                    if (email != null)
                    {
                        data.Email = email;
                    }
                    if (fullname != null)
                    {
                        data.Fullname = fullname;
                    }
                    if (avatarlink != null)
                    {
                        data.AvatarLink = avatarlink;
                    }
                    if (email == null && fullname == null && avatarlink == null)
                    {
                        return false;
                    }
                    data.UpdatedAt = DateTime.Now;
                    _db.Employee.Update(data);
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
    }
}
