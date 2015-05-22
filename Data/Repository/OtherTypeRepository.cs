using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class OtherTypeRepository : IOtherTypeRepository
    {
        private readonly DataModel _context;

        public OtherTypeRepository(DataModel context)
        {
            _context = context;
        }

        public IQueryable<OtherType> All
        {
            get { return _context.OtherTypes.AsQueryable(); }
        }

        public OtherType Find(int id)
        {
            return _context.OtherTypes.Find(id);
        }

        public void InsertOrUpdate(OtherType item)
        {
            if (item.Id == default(int))
            {
                _context.OtherTypes.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.OtherTypes.Find(id);
            _context.OtherTypes.Remove(temp);
        }
    }
}
