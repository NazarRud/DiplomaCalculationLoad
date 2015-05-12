using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class SubjectInfoBRepository : ISubjectInfoBRepository
    {
        private readonly DataModel _context;

        public SubjectInfoBRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<SubjectInfoB> All
        {
            get { return _context.SubjectInfosBs.AsQueryable(); }
        }

        public SubjectInfoB Find(int id)
        {
           return _context.SubjectInfosBs.Find(id);
        }

        public void InsertOrUpdate(SubjectInfoB item)
        {
            if (item.Id == default(int))
            {
                _context.SubjectInfosBs.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.SubjectInfosBs.Find(id);
            _context.SubjectInfosBs.Remove(temp);
        }
    }
}
