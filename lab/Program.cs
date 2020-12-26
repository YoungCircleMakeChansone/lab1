using lab.Builders;
using lab.Entities;
using lab.MongoContext;
using lab.MongoModels;
using lab.Presentation;
using lab.Repositories;
using System;
using System.Collections.Generic;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDbContext context = new MongoDbContext();
            MongoRepository _db = new MongoRepository(context);

            //MongoEvent item = new MongoEvent { Name = "event1", Format = "League", Sport = "table tennis" };

            //context.CollectionEvents.InsertOne(item);

            IEnumerable<MongoEvent> events = _db.GettAllSports();

            foreach(var item in events)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
