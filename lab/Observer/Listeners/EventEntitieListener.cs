using lab.Interfaces;
using System;

namespace lab.Observer.Listeners
{
    public class EventEntitieListener : IObserver
    {
        public void Update(string type, ISubject subject)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(type + " some entitie to event table");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
