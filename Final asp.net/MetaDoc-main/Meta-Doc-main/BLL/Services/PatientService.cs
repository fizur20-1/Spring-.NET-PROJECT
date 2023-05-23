using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static PatientDTO Create(PatientDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientDTO, Patient>();
                c.CreateMap<PatientDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_patient = mapper.Map<Patient>(obj);
            var result_patient = DataAccessFactory.PatientData().Create(data_patient);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Patient";
            var result_user = DataAccessFactory.UserData().Create(data_user);

            return obj;
        }

        //public static PatientDTO Delete(int Id)
        //{
        //    var data = DataAccessFactory.PatientData().Delete(Id);
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<Patient, PatientDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<PatientDTO>(data);
        //    return mapped;
        //}

        public static bool Delete(int Id)
        {
            var patient = DataAccessFactory.PatientData().Get(Id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
                c.CreateMap<Patient, UserDTO>();
            });
            var mapper = new Mapper(cfg);

            var result_patient = DataAccessFactory.PatientData().Delete(Id);
            var reult_user = DataAccessFactory.UserData().Delete(patient.Username);

            return result_patient;
        }

        public static PatientDTO Update(PatientDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientDTO, Patient>();
                c.CreateMap<PatientDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_patient = mapper.Map<Patient>(obj);
            var result_patient = DataAccessFactory.PatientData().Update(data_patient);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Patient";
            var result_user = DataAccessFactory.UserData().Update(data_user);

            return obj;
        }

        public static PatientReviewDTO GetwithReviews(int id)
        {
            var data = DataAccessFactory.PatientData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Patient, PatientReviewDTO>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientReviewDTO>(data);
            return mapped;
        }

        public static PatientAppoinmentInfoDTO GetwithAppointmentInfos(int id)
        {
            var data = DataAccessFactory.PatientData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Patient, PatientAppoinmentInfoDTO>();
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientAppoinmentInfoDTO>(data);
            return mapped;
        }
    }
}
