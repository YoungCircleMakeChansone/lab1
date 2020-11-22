using lab.Builders;
using lab.Entities;
using lab.Repositories;
using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork Database = new UnitOfWork("DefaultConnection");

            var builder = new EventBuilder(Database);

            builder.SetType("tournament");

            builder.SetName("Event num1");

            builder.AddSport("Football")
                .AddSport("Volleyball")
                .AddSport("Basketball");

            Database.Event.Add(builder.getEvent());
            Database.Save();


        }
    }
}
