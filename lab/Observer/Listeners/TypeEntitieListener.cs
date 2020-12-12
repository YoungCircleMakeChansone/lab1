using lab.Interfaces;
using System;

namespace lab.Observer.Listeners
{
    public class TypeEntitieListener : IObserver
    {
        public void Update(string type, ISubject subject)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(type + " some entitie to type table");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
