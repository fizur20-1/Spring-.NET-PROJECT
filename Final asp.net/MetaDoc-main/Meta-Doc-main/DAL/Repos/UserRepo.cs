using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (data != null) { return true; }
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(string User_Id)
        {
            var ex = Get(User_Id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string Username)
        {
            return db.Users.Find(Username);
        }

        public User Update(User obj)
        {
            var ex = Get(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }
    }
}
