using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, OrderDetail>
    {
        public OrderDetail Create(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.OrderDetails.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Get(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public OrderDetail Update(OrderDetail obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
