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
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public static ProductDTO Get(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public static ProductDTO Create(ProductDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Product>(obj);
            var result = DataAccessFactory.ProductData().Create(data);
            var redata = mapper.Map<ProductDTO>(result);
            return redata;
        }

        public static ProductDTO Delete(int Id)
        {
            var data = DataAccessFactory.ProductData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public static ProductDTO Update(ProductDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Product>(obj);
            var result = DataAccessFactory.ProductData().Update(data);
            var redata = mapper.Map<ProductDTO>(result);
            return redata;
        }
    }
}
