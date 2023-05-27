using AutoMapper;
using Microsoft.AspNetCore.Http;
using OMR_Service.DTOs;
using OMR_Service.EF;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace OMR_Service.Controllers
{
    public class CustomerController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;
        public CustomerController(OMRDBContext db, IMapper mapper)
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
        [Route("api/Customer/Register")]
        public bool Register(string phone, string password, string email, string fullname)
        {
            try
            {
                var data = _db.Customer.Where(x => x.Phone == phone).ToList();
                if (data.Count > 0)
                {
                    throw new Exception("Something Wrong"); 
                }
                else
                {
                    Customer customer = new Customer();
                    customer.Phone = phone;
                    customer.CreatedAt = DateTime.Now;
                    customer.Disturb = false;
                    var HashedPW = HashPassword($"{password}");
                    customer.Password = HashedPW;
                    customer.Email = email;
                    customer.Fullname = fullname;
                    _db.Customer.Add(customer);
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Something Wrong");
            }
        }
        [HttpPost]
        [Route("api/Customer/Login")]
        public int Login(string phone, string password)
        {
            try
            {
                if (_db.Customer.Where(x => x.Phone == phone).FirstOrDefault() == null)
                {
                    throw new Exception("Wrong Password");
                }
                else
                {
                    var data = _db.Customer.Where(x => x.Phone == phone).FirstOrDefault();
                    if (HashPassword($"{password}") == data.Password)
                    {
                        return data.CustomerID;
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
        [HttpGet]
        [Route("api/Customer/ReadAll")]
        public List<CustomerDTO> ReadAll()
        {
            try
            {
                var data = _db.Customer.ToList();
                if (data.Count > 0)
                {
                    return _mapper.Map<List<CustomerDTO>>(data);
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
        [Route("api/Customer/ReadOne")]
        public CustomerDTO ReadOne(int id)
        {
            try
            {
                var data = _db.Customer.Find(id);
                if (data != null)
                {
                    return _mapper.Map<CustomerDTO>(data);
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
        [Route("api/Customer/GetThisWeek")]
        public int GetThisWeek()
        {
            try
            {
                int count = _db.Customer.Where(x => x.CreatedAt >= DateTime.Now.AddDays(-7) && x.CreatedAt < DateTime.Now).Count();
                return count;

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("api/Customer/UpdatePassword")]
        public bool UpdatePassword(int id, string password, string npassword, string cnpassword)
        {
            try
            {
                var data = _db.Customer.Find(id);
                if (data != null)
                {
                    var HashedPW = HashPassword($"{password}");
                    if(HashedPW == data.Password && npassword == cnpassword) {
                        var HashedNPW = HashPassword($"{npassword}");
                        data.Password = HashedNPW;
                        data.UpdatedAt = DateTime.Now;
                        _db.Customer.Update(data);
                        _db.SaveChanges();
                        return true;
                    } else
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

        [HttpPut]
        [Route("api/Customer/UpdateProfile")]
        public bool UpdateProfile(int id, string email, string fullname, string avatarlink)
        {
            try
            {
                var data = _db.Customer.Find(id);
                


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
                    if(avatarlink != null)
                    {
                        data.AvatarLink = avatarlink;
                    }
                    if (email == null && fullname == null && avatarlink == null)
                    {
                        return false;
                    }
                    data.UpdatedAt = DateTime.Now;
                    _db.Customer.Update(data);
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
