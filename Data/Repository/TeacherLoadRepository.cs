using System.Data.Entity;
using System.Linq;
using Data.Entity;
namespace Data.Repository
{
    public class TeacherLoadRepository : ITeacherLoadRepository
    {
        private readonly DataModel _context;

        public TeacherLoadRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<TeacherLoad> All
        {
            get { return _context.TeacherLoads.AsQueryable(); }
        }

        public TeacherLoad Find(int id)
        {
            return _context.TeacherLoads.Find(id);
        }

        public void InsertOrUpdate(TeacherLoad item)
        {
            if (item.Id == default(int))
            {
                _context.TeacherLoads.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.TeacherInfos.Find(id);
            _context.TeacherInfos.Remove(temp);
        }
    }
}
