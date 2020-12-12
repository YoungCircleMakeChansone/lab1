namespace lab.Interfaces
{
    public interface IObserver
    {
        void Update(string type, ISubject subject);
    }
}
