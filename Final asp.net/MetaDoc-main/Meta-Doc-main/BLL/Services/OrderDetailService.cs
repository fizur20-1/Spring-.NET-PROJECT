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
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> Get()
        {
            var data = DataAccessFactory.OrderDetailData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDetailDTO>>(data);
            return mapped;
        }

        public static OrderDetailDTO Get(int Id)
        {
            var data = DataAccessFactory.OrderDetailData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDetailDTO>(data);
            return mapped;
        }
    }
}
