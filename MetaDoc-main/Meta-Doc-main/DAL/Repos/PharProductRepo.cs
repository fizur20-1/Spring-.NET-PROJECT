using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PharProductRepo : Repo, IRepo<PharProduct, int, PharProduct>
    {
        public PharProduct Create(PharProduct obj)
        {
            db.PharProducts.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.PharProducts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<PharProduct> Get()
        {
            return db.PharProducts.ToList();
        }

        public PharProduct Get(int id)
        {
            return db.PharProducts.Find(id);
        }

        public PharProduct Update(PharProduct obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
