using lab.Entities;
using lab.EntityFramework;
using lab.Memento;
using lab.MongoContext;
using lab.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Repositories
{
    public class UnitOfWork
    {
        private DataContext Database;
        private Snapshot Snapshot;
        private TypeRepository typeRepository;
        private EventRepository eventRepository;
        private SportRepository sportRepository;
        private RoleRepository roleRepository;
        private UserRepository userRepository;

        public UnitOfWork(string connection)
        {
            Database = ContextFactory.Create(connection);
            Snapshot = new Snapshot(Database);
        }

        public TypeRepository Type
        {
            get
            {
                if (typeRepository is null)
                    typeRepository = new TypeRepository(Database);
                return typeRepository;
            }
        }

        public EventRepository Event
        {
            get
            {
                if (eventRepository is null)
                    eventRepository = new EventRepository(Database);
                return eventRepository;
            }
        }

        public SportRepository Sport
        {
            get
            {
                if (sportRepository is null)
                    sportRepository = new SportRepository(Database);
                return sportRepository;
            }
        }

        public RoleRepository Role
        {
            get
            {
                if (roleRepository is null)
                    roleRepository = new RoleRepository(Database);
                return roleRepository;
            }
        }

        public UserRepository User
        {
            get
            {
                if (userRepository is null)
                    userRepository = new UserRepository(Database);
                return userRepository;
            }
        }

        public void Save()
        {
            Database.SaveChanges();
            Snapshot.Sports = Database.Set<Sport>();
        }

        public void Rollback()
        {
            Database.Sports = Snapshot.Sports;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ReplicateToMongo(MongoDbContext context)
        {
            MongoRepository _db = new MongoRepository(context);

            var items = this.Event.GetAll();

            foreach(var obj  in items)
            {
                MongoEvent item = new MongoEvent
                {
                    Name = obj.Name,
                    Format = "randomType",
                    Sport = "anysports"
                };

                context.CollectionEvents.InsertOne(item);
            }
        }

        public void ReplicateFromMongo(MongoDbContext context)
        {
            MongoRepository _db = new MongoRepository(context);
            var items = this.Event.GetAll();
            IEnumerable<MongoEvent> events = _db.GettAllSports();

            foreach (var obj in events)
            {
                Event @event = new Event
                {
                    Name = obj.Name,
                    Type = this.Type.GetAll().First()
                };

                this.Event.Add(@event);
            }
            this.Save();
        }
    }
}
