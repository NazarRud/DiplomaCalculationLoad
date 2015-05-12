using System;
using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataModel _context;

        public SubjectRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Subject> All
        {
            get { return _context.Subjects.AsQueryable(); }
        }

        public Subject Find(int id)
        {
            return _context.Subjects.Find(id);
        }

        public void InsertOrUpdate(Subject item)
        {
            if (item.Id == default(int))
            {
                _context.Subjects.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.Subjects.Find(id);
            _context.Subjects.Remove(temp);
        }
    }
}
