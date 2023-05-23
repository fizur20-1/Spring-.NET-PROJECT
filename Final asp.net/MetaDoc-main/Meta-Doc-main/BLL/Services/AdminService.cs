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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }

        public static AdminDTO Get(int Id)
        {
            var data = DataAccessFactory.AdminData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }
        public static AdminDTO Update(AdminDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<AdminDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_admin = mapper.Map<Admin>(obj);
            var result_admin = DataAccessFactory.AdminData().Update(data_admin);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Admin";
            var result_user = DataAccessFactory.UserData().Update(data_user);
            return obj;
        }
        public static AdminDTO Create(AdminDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<AdminDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_admin = mapper.Map<Admin>(obj);
            var result_admin = DataAccessFactory.AdminData().Create(data_admin);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Admin";
            var result_user = DataAccessFactory.UserData().Create(data_user);
            return obj;
        }
        public static bool Delete(int Id)
        {
            var admin = DataAccessFactory.AdminData().Get(Id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
                c.CreateMap<Admin, UserDTO>();
            });
            var mapper = new Mapper(cfg);

            var result_admin = DataAccessFactory.AdminData().Delete(Id);
            var reult_user = DataAccessFactory.UserData().Delete(admin.Username);

            return result_admin;
        }
    }
}
