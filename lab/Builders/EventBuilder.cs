using lab.Entities;
using lab.EntityFramework;
using lab.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab.Builders
{
    public class EventBuilder
    {
        private Event Event;
        private UnitOfWork Database;

        public EventBuilder(UnitOfWork db)
        {
            Database = db;
            Event = new Event();
        }

        public void SetName(string Name)
            => this.Event.Name = Name;
        public void SetType(string Name)
        {
            int type = Database.Type.GetByName(Name).Id;

            this.Event.TypeId = type;
        }

        public EventBuilder AddSport(string Name)
        {
            var sport = Database.Sport.GetByName(Name);
            this.Event.Sports.Add(sport);
            return this;
        }

        public Event build()
            => this.Event;
    }
}
