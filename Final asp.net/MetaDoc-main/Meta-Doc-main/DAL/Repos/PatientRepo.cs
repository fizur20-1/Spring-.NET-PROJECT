using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class PatientRepo : Repo, IRepo<Patient, int, Patient>, IPatientLogin<Patient, string>
    {
        public Patient Create(Patient obj)
        {
            db.Patients.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Patients.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Patient> Get()
        {
            return db.Patients.ToList();
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public Patient Match(string username)
        {
            return db.Patients.FirstOrDefault(x => x.Username == username);
        }

        public Patient Update(Patient obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
