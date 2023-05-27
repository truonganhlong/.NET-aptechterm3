using AutoMapper;
using OMR_Service.DTOs;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Injection;

namespace OMR_Service.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceProvider, ServiceProviderDTO>();
            CreateMap<Service, ServiceDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Notification, NotificationDTO>();
            CreateMap<Tune, TuneDTO>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<ServiceContract, ServiceContractDTO>();
        }
    }
}