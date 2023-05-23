using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorRepo : Repo, IRepo<Doctor, int, Doctor>, IDoctorLogin<Doctor, string>
    {
        public Doctor Create(Doctor obj)
        {
            db.Doctors.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

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
            return db.Doctors.Find(id);
        }

        public Doctor Match(string username)
        {
            return db.Doctors.FirstOrDefault(x => x.Username == username);
        }

        public Doctor Update(Doctor obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) 
                return obj;
            else return null;    
        }
    }
}
