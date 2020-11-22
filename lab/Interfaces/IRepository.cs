using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.Interfaces
{
    public interface IRepository<T> where T:class
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Delete(int Id);
        T GetByName(string Name);
    }
}
