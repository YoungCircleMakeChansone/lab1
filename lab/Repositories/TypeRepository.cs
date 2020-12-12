using lab.Entities;
using lab.EntityFramework;
using lab.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using lab.Observer;
using lab.Observer.Listeners;

namespace lab.Repositories
{
    public class TypeRepository : IRepository<EventType>
    {
        private DataContext Database;

        private EventManager events = new EventManager();

        public TypeRepository(DataContext db)
        {
            Database = db;

            events.Attach(new TypeEntitieListener());
        }

        public void Add(EventType item)
        {
            Database.Types.AddAsync(item);
            events.Notify("Add");
        }

        public void Delete(int Id)
        {
            var type = Database.Types.Find(Id);
            if(type is null)
            {
                Database.Types.Remove(type);
                return;
            }
            throw new NullReferenceException("There isn't type with this Id");
        }

        public EventType Get(int Id)
            =>  Database.Types.Find(Id);

        public IEnumerable<EventType> GetAll()
            => Database.Types.ToList();

        public EventType GetByName(string Name)
        {
            var types =  Database.Types.ToList();

            return types.Where(item => item.Name == Name).FirstOrDefault();
        }
    }
}
