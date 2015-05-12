using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class CathedraRepository : ICathedraRepository
    {
         private readonly DataModel _context;

        public CathedraRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Cathedra> All
        {
            get
            {
                return _context.Cathedras.AsQueryable();
            }
        }

        public Cathedra Find(int id)
        {
            return _context.Cathedras.Find(id);
        }

        public void InsertOrUpdate(Cathedra item)
        {
            if (item.Id == default(int))
            {
                _context.Cathedras.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.Cathedras.Find(id);
            _context.Cathedras.Remove(temp);
        }
    }
}
