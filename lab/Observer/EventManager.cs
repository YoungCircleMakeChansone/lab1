using lab.Interfaces;
using System.Collections.Generic;

namespace lab.Observer
{
    public class EventManager : ISubject
    {
        private List<IObserver> _observers;

        public EventManager()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify(string type)
        {
            foreach(var item in _observers)
            {
                item.Update(type, this);
            }
        }
    }
}
