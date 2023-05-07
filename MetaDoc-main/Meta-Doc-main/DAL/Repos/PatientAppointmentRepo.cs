using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class PatientAppointmentRepo : Repo, IRepo<PatientAppointment, int, PatientAppointment>
    {
        public PatientAppointment Create(PatientAppointment obj)
        {
            db.PatientAppointments.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.PatientAppointments.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<PatientAppointment> Get()
        {
            return db.PatientAppointments.ToList();
        }

        public PatientAppointment Get(int id)
        {
            return db.PatientAppointments.Find(id);
        }

        public PatientAppointment Update(PatientAppointment obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
