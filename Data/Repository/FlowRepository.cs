using System.Data.Entity;
using System.Linq;
using Data.Entity;
namespace Data.Repository
{
    public class FlowRepository : IFlowRepository
    {
        private readonly DataModel _context;

        public FlowRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Flow> All
        {
            get { return _context.Flows.AsQueryable(); }
        }

        public Flow Find(int id)
        {
           return _context.Flows.Find(id);
        }

        public void InsertOrUpdate(Flow item)
        {
            if (item.Id == default(int))
            {
                _context.Flows.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.Flows.Find(id);
            _context.Flows.Remove(temp);
        }
    }
}
