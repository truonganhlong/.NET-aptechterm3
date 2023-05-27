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
    public class TransactionController : ApiController
    {
        private OMRDBContext _db;
        private readonly IMapper _mapper;

        public TransactionController(OMRDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        [Route("api/Transaction/GetAllForAdmin")]
        public List<HistoryDTO> ReadAll()
        {
            try
            {
                List<TransactionDTO> dtos = _mapper.Map<List<TransactionDTO>>(_db.Transaction.ToList());
                List<HistoryDTO> list = new List<HistoryDTO>();
                foreach (TransactionDTO item2 in dtos)
                {
                    HistoryDTO item1 = new HistoryDTO();
                    item1.TransactionID = item2.TransactionID;
                    item1.Price = item2.Price;
                    item1.TransferTime = item2.TransferTime;
                    item1.Days = item2.Days;
                    item1.EndTime = item2.EndTime;
                    int serviceid = _db.ServiceContract.Where(x => x.ServiceContractID == item2.ServiceContractID).FirstOrDefault().ServiceID;
                    item1.ServiceDescription = _db.Service.Where(x => x.ServiceID == serviceid).FirstOrDefault().ServiceDescription;
                    item1.Fullname = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Fullname;
                    item1.Phone = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Phone;
                    item1.PaymentType = _db.Payment.Where(x => x.PaymentID == item2.PaymentID).FirstOrDefault().PaymentType;
                    list.Add(item1);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Transaction/GetAllForEmp")]
        public List<HistoryDTO> ReadAllForEmp(int serviceproviderid)
        {
            try
            {
                List<TransactionDTO> dtos = _mapper.Map<List<TransactionDTO>>(_db.Transaction.Where(x => x.ServiceContract.Service.ServiceProviderID == serviceproviderid).ToList());
                List<HistoryDTO> list = new List<HistoryDTO>();
                foreach (TransactionDTO item2 in dtos)
                {
                    HistoryDTO item1 = new HistoryDTO();
                    item1.TransactionID = item2.TransactionID;
                    item1.Price = item2.Price;
                    item1.TransferTime = item2.TransferTime;
                    item1.Days = item2.Days;
                    item1.EndTime = item2.EndTime;
                    int serviceid = _db.ServiceContract.Where(x => x.ServiceContractID == item2.ServiceContractID).FirstOrDefault().ServiceID;
                    item1.ServiceDescription = _db.Service.Where(x => x.ServiceID == serviceid).FirstOrDefault().ServiceDescription;
                    item1.Fullname = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Fullname;
                    item1.Phone = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Phone;
                    item1.PaymentType = _db.Payment.Where(x => x.PaymentID == item2.PaymentID).FirstOrDefault().PaymentType;
                    list.Add(item1);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Transaction/GetOneForAdmin")]
        public HistoryDTO ReadOne(int transactionid)
        {
            try
            {
                List<TransactionDTO> dtos = _mapper.Map<List<TransactionDTO>>(_db.Transaction.ToList());
                List<HistoryDTO> list = new List<HistoryDTO>();
                foreach (TransactionDTO item2 in dtos)
                {
                    HistoryDTO item1 = new HistoryDTO();
                    item1.TransactionID = item2.TransactionID;
                    item1.Price = item2.Price;
                    item1.TransferTime = item2.TransferTime;
                    item1.Days = item2.Days;
                    item1.EndTime = item2.EndTime;
                    int serviceid = _db.ServiceContract.Where(x => x.ServiceContractID == item2.ServiceContractID).FirstOrDefault().ServiceID;
                    item1.ServiceDescription = _db.Service.Where(x => x.ServiceID == serviceid).FirstOrDefault().ServiceDescription;
                    item1.Fullname = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Fullname;
                    item1.Phone = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Phone;
                    item1.PaymentType = _db.Payment.Where(x => x.PaymentID == item2.PaymentID).FirstOrDefault().PaymentType;
                    list.Add(item1);
                }
                return list.Find(x => x.TransactionID == transactionid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Transaction/ListAllByService")]
        public List<TransactionDTO> ListAllByService(int serviceid)
        {
            try
            {
                var data = _db.Transaction.Where(x => x.ServiceContract.ServiceID == serviceid).ToList();
                List<TransactionDTO> list = new List<TransactionDTO>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        list.Add(_mapper.Map<TransactionDTO>(item));
                    }
                    return list;
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
        [Route("api/Transection/ListAllByCustomer")]
        public List<HistoryDTO> ListAllByCustomer(int customerid)
        {
            try
            {
                List<TransactionDTO> dtos = _mapper.Map<List<TransactionDTO>>(_db.Transaction.Where(x => x.CustomerID == customerid).ToList());
                List<HistoryDTO> list = new List<HistoryDTO>();
                foreach (TransactionDTO item2 in dtos)
                {
                    HistoryDTO item1 = new HistoryDTO();
                    item1.TransactionID = item2.TransactionID;
                    item1.Price = item2.Price;
                    item1.TransferTime = item2.TransferTime;
                    item1.Days = item2.Days;
                    item1.EndTime = item2.EndTime;
                    int serviceid = _db.ServiceContract.Where(x => x.ServiceContractID == item2.ServiceContractID).FirstOrDefault().ServiceID;
                    item1.ServiceDescription = _db.Service.Where(x => x.ServiceID == serviceid).FirstOrDefault().ServiceDescription;
                    item1.Fullname = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Fullname;
                    item1.Phone = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Phone;
                    item1.PaymentType = _db.Payment.Where(x => x.PaymentID == item2.PaymentID).FirstOrDefault().PaymentType;
                    list.Add(item1);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //[HttpGet]
        //[Route("api/Transection/ListAllByHistory")]
        //public List<HistoryDTO> ListAllByHistory(List<TransactionDTO> dtos)
        //{
        //    try
        //    {
        //        List<HistoryDTO> list = new List<HistoryDTO>();
        //        foreach(HistoryDTO item1 in list)
        //        {
        //            foreach(TransactionDTO item2 in dtos)
        //            {
        //                item1.TransactionID= item2.TransactionID;
        //                item1.Price = item2.Price;
        //                item1.TransferTime = item2.TransferTime;
        //                item1.Days= item2.Days;
        //                item1.EndTime = item2.EndTime;
        //                int serviceid = _db.ServiceContract.Where(x => x.ServiceContractID == item2.ServiceContractID).FirstOrDefault().ServiceID;
        //                item1.ServiceDescription = _db.Service.Where(x => x.ServiceID== serviceid).FirstOrDefault().ServiceDescription;
        //                item1.Fullname = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Fullname;
        //                item1.Phone = _db.Customer.Where(x => x.CustomerID == item2.CustomerID).FirstOrDefault().Phone;
        //                item1.PaymentType = _db.Payment.Where(x => x.PaymentID == item2.PaymentID).FirstOrDefault().PaymentType;
        //                list.Add(item1);
        //            }
        //        }
        //        return list;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        public bool Create(TransactionDTO dto)
        {
            try
            {
                Transaction obj = new Transaction();
                obj.ServiceContractID = dto.ServiceContractID;
                obj.PaymentID = dto.PaymentID;
                obj.CustomerID = dto.CustomerID;
                obj.TransferTime = DateTime.Now;
                obj.Price = dto.Price;
                if(dto.Days != null)
                {
                    obj.Days = (int)dto.Days;
                    obj.EndTime = DateTime.Now.AddDays((int)dto.Days);
                }
                if(_db.Payment.Where(x => x.PaymentID == dto.PaymentID).FirstOrDefault().PaymentType == "Card")
                {
                    obj.CardNumber = dto.CardNumber;
                    obj.Expiry = dto.Expiry;
                    obj.CVV = dto.CVV;
                    obj.NameOnCard = dto.NameOnCard;
                } else
                {
                    obj.CardNumber = null;
                    obj.Expiry = null;
                    obj.CVV = null;
                    obj.NameOnCard = null;
                }
                
                _db.Transaction.Add(obj);
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Transaction/Count")]
        public int TransactionCount()
        {
            try
            {
                int count = _db.Transaction.Where(x => x.TransferTime >= DateTime.Now.AddDays(-7) && x.TransferTime < DateTime.Now).Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/Transaction/Revenue")]
        public decimal TransactionRevenue()
        {
            try
            {
                decimal revenue = 0;
                List<Transaction> list = _db.Transaction.Where(x => x.TransferTime >= DateTime.Now.AddDays(-7) && x.TransferTime < DateTime.Now).ToList();
                foreach(Transaction t in list)
                {
                    revenue += t.Price;
                }
                return revenue;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
