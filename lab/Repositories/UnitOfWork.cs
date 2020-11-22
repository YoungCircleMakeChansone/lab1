using lab.EntityFramework;
using System;
using System.Threading.Tasks;

namespace lab.Repositories
{
    public class UnitOfWork
    {
        private DataContext Database;

        private TypeRepository typeRepository;
        private EventRepository eventRepository;
        private SportRepository sportRepository;

        public UnitOfWork(string connection)
        {
            Database = ContextFactory.Create(connection);
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

        public void Save()
        {
            Database.SaveChanges();
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
    }
}
