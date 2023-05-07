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
    public class DiseaseSymptomService
    {
        public static List<DiseaseSymptomDTO> Get()
        {
            var data = DataAccessFactory.DiseaseSymptomData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DiseaseSymptomDTO>>(data);
            return mapped;
        }

        public static DiseaseSymptomDTO Get(int Id)
        {
            var data = DataAccessFactory.DiseaseSymptomData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiseaseSymptomDTO>(data);
            return mapped;
        }

        public static DiseaseSymptomDTO Create(DiseaseSymptomDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
                c.CreateMap<DiseaseSymptomDTO, DiseaseSymptom>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<DiseaseSymptom>(obj);
            var result = DataAccessFactory.DiseaseSymptomData().Create(data);
            var redata = mapper.Map<DiseaseSymptomDTO>(result);
            return redata;
        }

        public static DiseaseSymptomDTO Delete(int Id)
        {
            var data = DataAccessFactory.DiseaseSymptomData().Delete(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiseaseSymptomDTO>(data);
            return mapped;
        }

        public static DiseaseSymptomDTO Update(DiseaseSymptomDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiseaseSymptom, DiseaseSymptomDTO>();
                c.CreateMap<DiseaseSymptomDTO, DiseaseSymptom>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<DiseaseSymptom>(obj);
            var result = DataAccessFactory.DiseaseSymptomData().Update(data);
            var redata = mapper.Map<DiseaseSymptomDTO>(result);
            return redata;
        }
    }
}
