using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private DataContext _db;

        public RoleRepository(DataContext context)
        {
            _db = context;
        }
        public void Add(Role item)
        {
            _db.Add(item);
        }

        public void Delete(int Id)
        {
            var item = _db.Roles.Find(Id);
            _db.Remove(item);
        }

        public Role Get(int Id)
        {
            return _db.Roles.Find(Id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _db.Roles.ToList();
        }

        public Role GetByName(string Name)
        {
            return _db.Roles.ToList().Where(item => item.Name == Name).FirstOrDefault();
        }
    }
}
