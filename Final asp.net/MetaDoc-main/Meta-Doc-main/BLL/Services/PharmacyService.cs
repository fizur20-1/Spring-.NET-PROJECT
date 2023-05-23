using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PharmacyService
    {
        public static List<PharmacyDTO> Get()
        {
            var data = DataAccessFactory.PaymentData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Pharmacy, PharmacyDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PharmacyDTO>>(data);
            return mapped;
        }

        public static PharmacyDTO Get(int Id)
        {
            var data = DataAccessFactory.PharmacyData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Pharmacy, PharmacyDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PharmacyDTO>(data);
            return mapped;
        }

        public static PharmacyDTO Create(PharmacyDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharmacyDTO, Pharmacy>();
                c.CreateMap<PharmacyDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_pharmacy = mapper.Map<Pharmacy>(obj);
            var result_pharmacy = DataAccessFactory.PharmacyData().Create(data_pharmacy);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Pharmacy";
            var result_user = DataAccessFactory.UserData().Create(data_user);
            
            return obj;
        }

        public static bool Delete(int Id)
        {
            var pharmacy = DataAccessFactory.PharmacyData().Get(Id);
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Pharmacy, PharmacyDTO>();
                c.CreateMap<Pharmacy, UserDTO>();
            });
            var mapper = new Mapper(cfg);

            var result_pharmacy = DataAccessFactory.PharmacyData().Delete(Id);
            var reult_user = DataAccessFactory.UserData().Delete(pharmacy.Username);

            return result_pharmacy;
        }

        public static PharmacyDTO Update(PharmacyDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharmacyDTO, Pharmacy>();
                c.CreateMap<PharmacyDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_pharmacy = mapper.Map<Pharmacy>(obj);
            var result_pharmacy = DataAccessFactory.PharmacyData().Update(data_pharmacy);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Pharmacy";
            var result_user = DataAccessFactory.UserData().Update(data_user);

            return obj;
        }

        public static PharmacyOrderDTO GetwithOrders(int id)
        {
            var data = DataAccessFactory.PharmacyData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Pharmacy, PharmacyOrderDTO>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PharmacyOrderDTO>(data);
            return mapped;
        }

        public static PharmacyOrderDetailDTO GetwithOrderDetail(int id)
        {
            var data = DataAccessFactory.PharmacyData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Pharmacy, PharmacyOrderDetailDTO>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PharmacyOrderDetailDTO>(data);
            return mapped;
        }
    }
}
