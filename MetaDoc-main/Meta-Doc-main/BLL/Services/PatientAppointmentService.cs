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
    public class PatientAppointmentService
    {
        public static List<PatientAppoinmentDTO> Get()
        {
            var data = DataAccessFactory.PatientAppointmentData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PatientAppoinmentDTO>>(data);
            return mapped;
        }

        public static PatientAppoinmentDTO Get(int Id)
        {
            var data = DataAccessFactory.PatientAppointmentData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientAppoinmentDTO>(data);
            return mapped;
        }

        public static PatientAppoinmentDTO Create(PatientAppoinmentDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
                c.CreateMap<PatientAppoinmentDTO, PatientAppointment>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<PatientAppointment>(obj);
            var result = DataAccessFactory.PatientAppointmentData().Create(data);
            var redata = mapper.Map<PatientAppoinmentDTO>(result);
            return redata;
        }

        public static PatientAppoinmentDTO Delete(int Id)
        {
            var data = DataAccessFactory.PatientAppointmentData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientAppoinmentDTO>(data);
            return mapped;
        }

        public static PatientAppoinmentDTO Update(PatientAppoinmentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientAppointment, PatientAppoinmentDTO>();
                c.CreateMap<PatientAppoinmentDTO, PatientAppointment>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<PatientAppointment>(obj);
            var result = DataAccessFactory.PatientAppointmentData().Update(data);
            var redata = mapper.Map<PatientAppoinmentDTO>(result);
            return redata;
        }
    }
}
