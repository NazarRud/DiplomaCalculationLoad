using System.Data.Entity;
using System.Linq;
using Data.Entity;
namespace Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataModel _context;

        public PaymentRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<Payment> All
        {
            get { return _context.Payments.AsQueryable(); }
        }

        public Payment Find(int id)
        {
            return _context.Payments.Find(id);
        }

        public void InsertOrUpdate(Payment item)
        {
             if (item.Id == default(int))
            {
                _context.Payments.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
             var temp = _context.Payments.Find(id);
            _context.Payments.Remove(temp);
        }
    }
}
