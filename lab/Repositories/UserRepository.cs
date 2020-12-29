using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private DataContext _db;

        public UserRepository(DataContext context)
        {
            _db = context;
        }
        public void Add(User item)
        {
            _db.Add(item);
        }

        public void Delete(int Id)
        {
            var item = _db.Users.Find(Id);
            _db.Users.Remove(item);
        }

        public User Get(int Id)
        {
            return _db.Users.Find(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetByName(string Name)
        {
            return _db.Users.ToList().Where(item => item.Login == Name).FirstOrDefault();
        }
    }
}
