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
    public class UserController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public UserController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);


            return BitConverter.ToString(hashedpassword).Replace("-", string.Empty); ;

        }
        [HttpPost]
        [Route("api/User/Register")]
        public bool Register(string username, string password, int employeeid)
        {
            try
            {
                var data = _db.Users.Where(x => x.Username == username).ToList();
                if (data.Count > 0)
                {
                    throw new Exception("Something Wrong");
                }
                else
                {
                    User user = new User();
                    user.Username = username;
                    user.EmployeeID = employeeid;
                    var HashedPW = HashPassword($"{password}");
                    user.Password = HashedPW;
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    AddGroupUser(user.UserID);
                    return true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Something Wrong");
            }
        }
        [HttpPost]
        [Route("api/User/Login")]
        public int Login(string username, string password)
        {
            try
            {
                if (_db.Users.Where(x => x.Username == username).FirstOrDefault() == null)
                {
                    throw new Exception("Wrong Password");
                }
                else
                {
                    var data = _db.Users.Where(x => x.Username == username).FirstOrDefault();
                    if (HashPassword($"{password}") == data.Password)
                    {
                        return data.UserID;
                    }
                    else
                    {
                        throw new Exception("Wrong Password");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("api/User/UpdatePassword")]
        public bool UpdatePassword(int id, string password, string npassword, string cnpassword)
        {
            try
            {
                var data = _db.Users.Find(id);
                if (data != null)
                {
                    var HashedPW = HashPassword($"{password}");
                    if (HashedPW == data.Password && npassword == cnpassword)
                    {
                        var HashedNPW = HashPassword($"{npassword}");
                        data.Password = HashedNPW;
                        _db.Users.Update(data);
                        _db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        [HttpPost]
        [Route("api/User/CheckAdmin")]
        public bool CheckAdmin(int userid)
        {
            try
            {
                int groupid = _db.Group.Where(x => x.GroupUser.FirstOrDefault().UserID == userid).FirstOrDefault().GroupID;
                if(groupid == 1)
                {
                    return true;
                } else { throw new Exception("not admin"); }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("api/User/CheckEmp")]
        public int CheckEmployee(int userid)
        {
            try
            {
                int? serviceproviderid = _db.Employee.Where(x => x.User.FirstOrDefault().UserID == userid).FirstOrDefault().ServiceProviderID;
                if(serviceproviderid != null) {
                    return (int)serviceproviderid;
                } else
                {
                    throw new Exception("Something wrong");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddGroupUser(int userid)
        {
            try
            {
                GroupUser obj = new GroupUser();
                obj.UserID = userid;
                obj.GroupID = 2;
                _db.GroupUser.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
