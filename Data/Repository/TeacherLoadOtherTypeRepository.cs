using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class TeacherLoadOtherTypeRepository :ITeacherLoadOtherTypeRepository
    {
        private DataModel _context;

        public TeacherLoadOtherTypeRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<TeacherLoadOtherType> All
        {
            get { return _context.TeacherLoadOtherTypes.AsQueryable(); }
        }

        public TeacherLoadOtherType Find(int id)
        {
            return _context.TeacherLoadOtherTypes.Find(id);
        }

        public void InsertOrUpdate(TeacherLoadOtherType item)
        {
            if (item.Id == default (int))
            {
                _context.TeacherLoadOtherTypes.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.TeacherLoadOtherTypes.Find(id);
            _context.TeacherLoadOtherTypes.Remove(temp);

        }
    }
}
