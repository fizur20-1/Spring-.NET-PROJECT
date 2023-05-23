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
                c.CreateMap<DoctorDTO, Doctor>();
                c.CreateMap<DoctorDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_doctor = mapper.Map<Doctor>(obj);
            var result_doctor = DataAccessFactory.DoctorData().Create(data_doctor);
            
            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Doctor";
            var result_user = DataAccessFactory.UserData().Create(data_user);
            //var redata = mapper.Map<DoctorDTO>(result_doctor);
            //var redata1 = mapper.Map<UserDTO>(result_user);
            return obj;
        }

        public static bool Delete(int Id)
        {
            var doctor = DataAccessFactory.DoctorData().Get(Id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<Doctor,UserDTO>();
            });
            var mapper = new Mapper(cfg);

            var result_doctor = DataAccessFactory.DoctorData().Delete(Id);
            var reult_user = DataAccessFactory.UserData().Delete(doctor.Username);

            return result_doctor;
        }

        public static DoctorDTO Update(DoctorDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
                c.CreateMap<DoctorDTO, User>();
            });
            var mapper = new Mapper(cfg);

            var data_doctor = mapper.Map<Doctor>(obj);
            var result_doctor = DataAccessFactory.DoctorData().Update(data_doctor);

            var data_user = mapper.Map<User>(obj);
            data_user.Role = "Doctor";
            var result_user = DataAccessFactory.UserData().Update(data_user);
            return obj;
        }

        public static DoctorReviewDTO GetwithReviews(int id)
        {
            var data = DataAccessFactory.DoctorData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorReviewDTO>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DoctorReviewDTO>(data);
            return mapped;
        }

        public static DoctorAppointmentDTO GetwithAppointment(int id)
        {
            var data = DataAccessFactory.DoctorData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorAppointmentDTO>();
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DoctorAppointmentDTO>(data);
            return mapped;
        }

        public static DoctorDiseaseSymptomDTO GetwithDiseaseSymptoms(int id)
        {
            var data = DataAccessFactory.DoctorData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorDiseaseSymptomDTO>();
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DoctorDiseaseSymptomDTO>(data);
            return mapped;
        }
    }
}