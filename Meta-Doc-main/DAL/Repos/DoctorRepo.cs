using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorRepo : Repo, IRepo<Doctor, int, Doctor>
    {
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Doctors.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<Doctor> Get()
        {
            return db.Doctors.ToList();
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find();
        }

        public Doctor Insert(Doctor obj)
        {
            db.Doctors.Add(obj);
            if(db.SaveChanges()>0) return obj;
            else return null;
        }

        public Doctor Update(Doctor obj)
        {
            var ex = Get(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) return obj;
            else return null;    
        }
    }
}
