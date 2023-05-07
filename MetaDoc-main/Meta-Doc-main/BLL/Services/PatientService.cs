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
    public class PatientService
    {
        public static List<PatientDTO> Get()
        {
            var data = DataAccessFactory.PatientData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PatientDTO>>(data);
            return mapped;
        }

        public static PatientDTO Get(int Id)
        {
            var data = DataAccessFactory.PatientData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientDTO>(data);
            return mapped;
        }

        public static PatientDTO Create(PatientDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
                c.CreateMap<PatientDTO, Patient>();
                c.CreateMap<Patient, UserDTO>();
                c.CreateMap<UserDTO, Patient>();
            });
            var mapper = new Mapper(cfg);

            var data = mapper.Map<Patient>(obj);
            var result = DataAccessFactory.PatientData().Create(data);
            var data1 = mapper.Map<User>(obj);
            data1.Role = "Patient";
            var result1 = DataAccessFactory.UserData().Create(data1);
            var redata = mapper.Map<PatientDTO>(result);
            return redata;
        }

        public static PatientDTO Delete(int Id)
        {
            var data = DataAccessFactory.PatientData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientDTO>(data);
            return mapped;
        }

        public static PatientDTO Update(PatientDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
                c.CreateMap<PatientDTO, Patient>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Patient>(obj);
            var result = DataAccessFactory.PatientData().Update(data);
            var redata = mapper.Map<PatientDTO>(result);
            return redata;
        }
    }
}
