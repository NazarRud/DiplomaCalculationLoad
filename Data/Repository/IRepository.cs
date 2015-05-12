using System.Linq;

namespace Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        T Find(int id);
        void InsertOrUpdate(T item);
        void Delete(int id);
    }
}
