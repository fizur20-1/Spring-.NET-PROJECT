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
    public class DoctorService
    {
        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DoctorDTO>>(data);
            return mapped;
        }

        public static DoctorDTO Get(int Id)
        {
            var data = DataAccessFactory.DoctorData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DoctorDTO>(data);
            return mapped;
        }

        public static DoctorDTO Create(DoctorDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<DoctorDTO, Doctor>();
                c.CreateMap<Doctor, UserDTO>();
                c.CreateMap<UserDTO, Doctor>(); //this line is redundant, though we didn't return UserDTO type
            });
            var mapper = new Mapper(cfg);

            var data = mapper.Map<Doctor>(obj);
            var result = DataAccessFactory.DoctorData().Create(data);
            var data1 = mapper.Map<User>(obj);
            data1.Role = "Doctor";
            var result1 = DataAccessFactory.UserData().Create(data1);
            var redata = mapper.Map<DoctorDTO>(result);
            return redata;
        }

        public static DoctorDTO Delete(int Id)
        {
            var data = DataAccessFactory.DoctorData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DoctorDTO>(data);
            return mapped;
        }

        public static DoctorDTO Update(DoctorDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Doctor>(obj);
            var result = DataAccessFactory.DoctorData().Update(data);
            var redata = mapper.Map<DoctorDTO>(result);
            return redata;
        }
    }
}