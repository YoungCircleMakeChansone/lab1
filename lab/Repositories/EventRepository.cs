using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace lab.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private DataContext Database;

        public EventRepository(DataContext db)
        {
            Database = db;
        }

        public void Add(Event item)
            =>  Database.Events.Add(item);

        public void Delete(int Id)
        {
            var someEvent = Database.Events.Find(Id);

            if(someEvent is null)
            {
                Database.Events.Remove(someEvent);
                return;
            }
            throw new NullReferenceException("There isn't event with this Id");
        }

        public Event Get(int Id)
            => Database.Events.Find(Id);

        public IEnumerable<Event> GetAll()
            => Database.Events.ToList();

        public Event GetByName(string Name)
        {
            var tasks = Database.Events.ToList();

            return tasks.Where(item => item.Name == Name).FirstOrDefault();
        }

    }
}
