using System.Collections.Generic;

namespace PrymApp.Data.Repository
{
    public interface IRepository<T>
    {
        IList<T> GetAll();

        T Get(int id);

        T Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}
