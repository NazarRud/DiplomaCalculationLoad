using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class SubGroupRepository :ISubGroupRepository
    {
        private readonly DataModel _context;

        public SubGroupRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<SubGroup> All
        {
            get { return _context.SubGroups.AsQueryable(); }
        }

        public SubGroup Find(int id)
        {
           return _context.SubGroups.Find(id);
        }

        public void InsertOrUpdate(SubGroup item)
        {
            if (item.Id == default(int))
            {
                _context.SubGroups.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.SubGroups.Find(id);
            _context.SubGroups.Remove(temp);
        }
    }
}
