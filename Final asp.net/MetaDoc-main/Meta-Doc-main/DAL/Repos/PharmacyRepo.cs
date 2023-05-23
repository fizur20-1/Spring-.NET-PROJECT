using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PharmacyRepo : Repo, IRepo<Pharmacy, int, Pharmacy>, IPharmacyLogin<Pharmacy, string>
    {
        public Pharmacy Create(Pharmacy obj)
        {
            db.Pharmacies.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Pharmacies.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Pharmacy> Get()
        {
            return db.Pharmacies.ToList();
        }

        public Pharmacy Get(int id)
        {
            return db.Pharmacies.Find(id);
        }

        public Pharmacy Match(string username)
        {
            return db.Pharmacies.FirstOrDefault(x => x.Username == username);
        }

        public Pharmacy Update(Pharmacy obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
