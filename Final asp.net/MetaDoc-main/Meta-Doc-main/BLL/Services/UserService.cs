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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }

        public static UserDTO Get(string Username)
        {
            var data = DataAccessFactory.UserData().Get(Username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }
        public static UserDTO Delete(string Username)
        {
            var data = DataAccessFactory.UserData().Delete(Username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }

        public static UserDTO Update(UserDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<User>(obj);
            var result = DataAccessFactory.UserData().Update(data);
            var redata = mapper.Map<UserDTO>(result);
            return redata;
        }
    }
}
