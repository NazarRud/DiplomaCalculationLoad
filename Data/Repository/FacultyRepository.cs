using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
         private readonly DataModel _context;

        public FacultyRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Faculty> All
        {
            get
            {
                return _context.Faculties.AsQueryable();
            }
        }

        public Faculty Find(int id)
        {
            return _context.Faculties.Find(id);
        }

        public void InsertOrUpdate(Faculty item)
        {
            if (item.Id == default(int))
            {
                _context.Faculties.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.Faculties.Find(id);
            _context.Faculties.Remove(temp);
        }
    }
}
