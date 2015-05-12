using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class TeacherInfoRepository :ITeacherInfoRepository
    {
        private readonly DataModel _context;

        public TeacherInfoRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<TeacherInfo> All
        {
            get { return _context.TeacherInfos.AsQueryable(); }
        }

        public TeacherInfo Find(int id)
        {
           return _context.TeacherInfos.Find(id);
        }

        public void InsertOrUpdate(TeacherInfo item)
        {
            if (item.Id == default(int))
            {
                _context.TeacherInfos.Add(item);
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
