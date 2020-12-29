using lab.Entities;
using lab.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab.Proxy
{
    public class ViewControllerProxy
    {
        private ViewController service;
        private User user;


        public ViewControllerProxy(ViewController view)
        {
            this.service = view;
            user = service.Database.User.Get(2);
        }

        public void AllSports()
        {
            service.AllSports();
        }

        public void AllEventsTypes()
        {
            service.AllEventsTypes();
        }

        public void AllEvents()
        {
            service.AllEvents();
        }

        public void AddSport()
        {
            if (user.RoleId == 2)
            {
                service.AddSport();
            }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void DeleteSport()
        {
            if (user.RoleId == 2)
            {
                service.DeleteSport();
            }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void AddType()
        {
            if (user.RoleId == 2)
            {
                service.AddType();
            }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void DeleteType()
        {
            if (user.RoleId == 2)
            {
                service.DeleteType();
            }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void AddEvent()
        {
            if(user.RoleId ==2)
            {
                service.AddEvent();
            }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void DeleteEvent()
        {
           if(user.Role.Name == "admin")
           {
                service.DeleteEvent();
           }
            else
            {
                Console.WriteLine("No access");
            }
        }

        public void LogIn()
        {
            //this.user = service.LogIn();
            
        }
        public void LogOut()
        {
            user = null;
        }

        public void Run()
        {

            if (user is null)
                Console.WriteLine("Please login");

            ConsoleKeyInfo key1 = Console.ReadKey();
            ConsoleKeyInfo key2 = Console.ReadKey();
            Dictionary<ConsoleKey, Action> action = new Dictionary<ConsoleKey, Action>();

            if (key1.Key == ConsoleKey.G)
            {
                Console.WriteLine();
                action.Add(ConsoleKey.S, new Action(this.AllSports));
                action.Add(ConsoleKey.T, new Action(this.AllEventsTypes));
                action.Add(ConsoleKey.E, new Action(this.AllEvents));
            }
            else if(key1.Key == ConsoleKey.L)
            {
                Console.WriteLine();
                this.LogIn();
                this.Run();
            }
            else if(key1.Key == ConsoleKey.O)
            {
                Console.WriteLine();
                this.LogOut();
                this.Run();
            }
            else if (key1.Key == ConsoleKey.A)
            {
                Console.WriteLine();
                action.Add(ConsoleKey.S, new Action(this.AddSport));
                action.Add(ConsoleKey.T, new Action(this.AddType));
                action.Add(ConsoleKey.E, new Action(this.AddEvent));
            }
            else if (key1.Key == ConsoleKey.D)
            {
                Console.WriteLine();
                action.Add(ConsoleKey.S, new Action(this.DeleteSport));
                action.Add(ConsoleKey.T, new Action(this.DeleteType));
                action.Add(ConsoleKey.E, new Action(this.DeleteEvent));
            }

            action[key2.Key].Invoke();

            this.Run();
        }
    }
}
