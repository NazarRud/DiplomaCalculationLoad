using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class SubjectInfoKRepository : ISubjectInfoKRepository
    {
         private readonly DataModel _context;

        public SubjectInfoKRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<SubjectInfoK> All
        {
            get { return _context.SubjectInfosKs.AsQueryable(); }
        }

        public SubjectInfoK Find(int id)
        {
           return _context.SubjectInfosKs.Find(id);
        }

        public void InsertOrUpdate(SubjectInfoK item)
        {
            if (item.Id == default(int))
            {
                _context.SubjectInfosKs.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.SubjectInfosKs.Find(id);
            _context.SubjectInfosKs.Remove(temp);
        }
    }
}
