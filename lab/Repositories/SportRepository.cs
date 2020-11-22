using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lab.Repositories
{
    public class SportRepository: IRepository<Sport>
    {
        private DataContext Database;

        public SportRepository(DataContext db)
        {
            Database = db;
        }

        public void Add(Sport item)
        {
            Database.Sports.Add(item);
        }

        public void Delete(int Id)
        {
            var sport = Database.Sports.Find(Id);
            if (sport is null)
            {
                Database.Remove(sport);
                return;
            }
            throw new NullReferenceException("There isn't sport with this Id");
        }

        public Sport Get(int Id)
            => Database.Sports.Find(Id);

        public IEnumerable<Sport> GetAll()
            => Database.Sports.ToList();

        public Sport GetByName(string Name)
        {
            var sports = Database.Sports.ToList();

            return sports.Where(item => item.Name == Name).FirstOrDefault();
        }
    }
}
