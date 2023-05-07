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
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }

        public static OrderDTO Get(int Id)
        {
            var data = DataAccessFactory.OrderData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }

        public static OrderDTO Create(OrderDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Order>(obj);
            var result = DataAccessFactory.OrderData().Create(data);
            var redata = mapper.Map<OrderDTO>(result);
            return redata;
        }

        public static OrderDTO Delete(int Id)
        {
            var data = DataAccessFactory.OrderData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }

        public static OrderDTO Update(OrderDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Order>(obj);
            var result = DataAccessFactory.OrderData().Update(data);
            var redata = mapper.Map<OrderDTO>(result);
            return redata;
        }
    }
}
