using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class ReviewRepo : Repo, IRepo<Review, int, Review>
    {
        public Review Create(Review obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public Review Update(Review obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
