using lab.Entities;
using lab.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lab.Memento
{
    public class Snapshot
    {
        public DataContext _db;
        private DbSet<Sport> snapshotSport;

        public Snapshot(DataContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _db = context;
            snapshotSport = _db.Set<Sport>();
        }

     

        public DbSet<Sport> Sports
        {
            get => snapshotSport;
            set => snapshotSport = value;
        }
    }
}
