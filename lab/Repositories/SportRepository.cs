using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using lab.Observer;
using lab.Observer.Listeners;

namespace lab.Repositories
{
    public class SportRepository: IRepository<Sport>
    {
        private DataContext Database;

        private EventManager events = new EventManager();

        public SportRepository(DataContext db)
        {
            Database = db;

            events.Attach(new SportEntitieListener());
        }

        public void Add(Sport item)
        {
            Database.Sports.Add(item);
            events.Notify("Add");
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
