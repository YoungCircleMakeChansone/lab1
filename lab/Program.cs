using lab.Builders;
using lab.Entities;
using lab.MongoContext;
using lab.MongoModels;
using lab.Presentation;
using lab.Proxy;
using lab.Repositories;
using System;
using System.Collections.Generic;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewController view = new ViewController("DefaultConnection");
            ViewControllerProxy proxy = new ViewControllerProxy(view);
            proxy.Run();
            //view.Run();
            //MongoDbContext context = new MongoDbContext();
            //MongoRepository _db = new MongoRepository(context);

            //MongoEvent item = new MongoEvent { Name = "football1", Format = "League", Sport = "EPL1" };

            //context.CollectionEvents.InsertOne(item);

            //IEnumerable<MongoEvent> events = _db.GettAllSports();

            //foreach (var item1 in events)
            //{
            //    Console.WriteLine("Event : ");
            //    Console.WriteLine(item1.Name);
            //}



        }
    }
}
