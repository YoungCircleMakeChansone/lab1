using lab.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab.EntityFramework
{
    public class DataContext:DbContext
    {
        private static DataContext db;
        private DataContext(DbContextOptions<DataContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public static DataContext GetContext(DbContextOptions<DataContext> options)
        {
            if (db is null)
                db = new DataContext(options);
            return db;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> Types { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
