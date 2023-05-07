using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class DiseaseSymptomRepo : Repo, IRepo<DiseaseSymptom, int, DiseaseSymptom>
    {
        public DiseaseSymptom Create(DiseaseSymptom obj)
        {
            db.DiseaseSymptoms.Add(obj);
            if (db.SaveChanges() > 0) 
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.DiseaseSymptoms.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<DiseaseSymptom> Get()
        {
            return db.DiseaseSymptoms.ToList();
        }

        public DiseaseSymptom Get(int id)
        {
            return db.DiseaseSymptoms.Find(id);
        }

        public DiseaseSymptom Update(DiseaseSymptom obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
