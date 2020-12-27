using lab.Builders;
using lab.Entities;
using lab.Repositories;
using System;
using System.Collections.Generic;

namespace lab.Presentation
{
    public class ViewController
    {
        private UnitOfWork Database;

        public ViewController(string stringconnection)
        {
            Database = new UnitOfWork(stringconnection);
        }

        public void AllSports()
        {
            var sports = Database.Sport.GetAll();

            foreach(var item in sports)
            {
                Console.WriteLine(item.Id+"\t"+item.Name+"\t"+
                    "events number : "+item.Events.Count);
            }
        }

        public void AllEventsTypes()
        {
            var types = Database.Type.GetAll();

            foreach(var item in types)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
            }
        }

        public void AllEvents()
        {
            var events = Database.Event.GetAll();

            foreach(var item in events)
            {
                Console.WriteLine(item.Id+"\t"+item.Name+"\t");
            }

        }

        public void AddSport()
        {
            Console.WriteLine("Enter sport name : ");
            string name = Console.ReadLine();

            if(Database.Sport.GetByName(name) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such sport exists");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Database.Sport.Add(new Sport { Name = name });
            Database.Save();
        }

        public void DeleteSport()
        {
            Console.WriteLine("Enter sport name : ");

            string name = Console.ReadLine();

            if (Database.Sport.GetByName(name) is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such sport not exists");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Database.Sport.Delete(Database.Sport.GetByName(name).Id);
            Database.Save();
        }

        public void AddType()
        {
            Console.WriteLine("Enter type name : ");
            string name = Console.ReadLine();

            if (Database.Type.GetByName(name) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such event type exists");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Database.Type.Add(new EventType { Name = name });
            Database.Save();
        }

        public void DeleteType()
        {
            Console.WriteLine("Enter type name : ");

            string name = Console.ReadLine();

            if (Database.Sport.GetByName(name) is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such type not exists");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Database.Type.Delete(Database.Type.GetByName(name).Id);
            Database.Save();
        }

        public void AddEvent()
        {

            Console.WriteLine("Enter event name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter type name : ");
            string type = Console.ReadLine();

            if (Database.Type.GetByName(type) is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such type not exists, try again");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            var builder = new EventBuilder(Database);

            Console.WriteLine("Enter sports number : ");

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter sports : ");
            for (int i = 0; i < num; i++)
            {
                var item = Console.ReadLine();
                builder.AddSport(item);
            }

            builder.SetType(type);
            builder.SetName(name);

            Database.Event.Add(builder.build());
            Database.Save();
        }

        public void DeleteEvent()
        {
            Console.WriteLine("Enter event name : ");

            string name = Console.ReadLine();

            if (Database.Event.GetByName(name) is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such type not exists");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Database.Event.Delete(Database.Event.GetByName(name).Id);
            Database.Save();
        }

        public void Run()
        {
            ConsoleKeyInfo key1 = Console.ReadKey();
            ConsoleKeyInfo key2 = Console.ReadKey();
            Dictionary<ConsoleKey, Action> action = new Dictionary<ConsoleKey, Action>();

            if(key1.Key == ConsoleKey.G)
            {
                action.Add(ConsoleKey.S, new Action(this.AllSports));
                action.Add(ConsoleKey.T, new Action(this.AllEventsTypes));
                action.Add(ConsoleKey.E, new Action(this.AllEvents));
            }
            else if(key1.Key == ConsoleKey.A)
            {
                action.Add(ConsoleKey.S, new Action(this.AddSport));
                action.Add(ConsoleKey.T, new Action(this.AddType));
                action.Add(ConsoleKey.E, new Action(this.AddEvent));
            }
            else if(key1.Key == ConsoleKey.D)
            {
                action.Add(ConsoleKey.S, new Action(this.DeleteSport));
                action.Add(ConsoleKey.T, new Action(this.DeleteType));
                action.Add(ConsoleKey.E, new Action(this.DeleteEvent));
            }
            
            action[key2.Key].Invoke();

            this.Run();
        }
    }
}
