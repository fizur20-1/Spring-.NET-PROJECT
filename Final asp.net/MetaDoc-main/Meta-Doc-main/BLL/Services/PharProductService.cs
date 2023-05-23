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
    public class PharProductService
    {
        public static List<PharProductDTO> Get()
        {
            var data = DataAccessFactory.PharProductData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharProduct, PharProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PharProductDTO>>(data);
            return mapped;
        }

        public static PharProductDTO Get(int Id)
        {
            var data = DataAccessFactory.PharProductData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharProduct, PharProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PharProductDTO>(data);
            return mapped;
        }

        public static PharProductDTO GetPhar(int Id)
        {
            var data = DataAccessFactory.PharProductData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharProduct, PharProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PharProductDTO>(data);
            return mapped;
        }
    }
}
