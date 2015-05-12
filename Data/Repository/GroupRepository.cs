using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataModel _context;

        public GroupRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Group> All
        {
            get { return _context.Groups.AsQueryable(); }
        }

        public Group Find(int id)
        {
           return _context.Groups.Find(id);
        }

        public void InsertOrUpdate(Group item)
        {
            if (item.Id == default(int))
            {
                _context.Groups.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.Groups.Find(id);
            _context.Groups.Remove(temp);
        }
    }
}
