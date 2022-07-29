using AppointIT.Model.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointIT.Services.Mapping
{
    public class AppointITProfile:Profile
    {
        public AppointITProfile()
        {
            CreateMap<Database.Category, Category>();
            CreateMap<Category, Database.Category>();

            CreateMap<Database.Service, Service>();
            CreateMap<Model.Requests.ServiceInsertRequest, Database.Service>();

            CreateMap<Database.BaseUser, BaseUser>().ReverseMap();
            CreateMap<Model.Requests.BaseUserInsertRequest, Database.BaseUser>();
            CreateMap<Database.Role, Role>();
            CreateMap<Database.BaseUserRole, BaseUserRole>();
            CreateMap<Database.City, City>();
            CreateMap<Database.Salon, Salon>();
            CreateMap<Model.Requests.SalonInsertRequest, Database.Salon>();
            CreateMap<Model.Requests.EmployeeInsertRequest, Database.Employee>();
            CreateMap<Database.Employee, Employee>();
            CreateMap<Database.SalonServices, SalonServices>().ReverseMap();
            CreateMap<Term, Database.Term>().ReverseMap();
            CreateMap<Model.Requests.TermInsertRequest, Database.Term>().ReverseMap();
            CreateMap<News, Database.News>().ReverseMap();
            CreateMap<Model.Requests.NewsInsertRequest, Database.News>();
            CreateMap<Model.Requests.CouponInsertRequest, Database.Coupon>();
            CreateMap<Model.Requests.CustomerCouponInsertRequest, Database.CustomerCoupon>();

            CreateMap<Database.Coupon, Coupon>();
            CreateMap<Database.CustomerCoupon, CustomerCoupon>();
            CreateMap<Database.Customer, Customer>();

        }
    }
}
