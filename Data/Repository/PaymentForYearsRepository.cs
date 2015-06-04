using System.Data.Entity;
using System.Linq;
using Data.Entity;

namespace Data.Repository
{
    public class PaymentForYearsRepository : IPaymentForYearsRepository
    {
        private readonly DataModel _context;
        public PaymentForYearsRepository(DataModel context)
        {
            _context = context;
        }
        public IQueryable<PaymentForYears> All
        {
            get { return _context.PaymentForYearses.AsQueryable(); }
        }

        public PaymentForYears Find(int id)
        {
            return _context.PaymentForYearses.Find(id);
        }

        public void InsertOrUpdate(PaymentForYears item)
        {
            if (item.Id == default(int))
            {
                _context.PaymentForYearses.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var temp = _context.PaymentForYearses.Find(id);
            _context.PaymentForYearses.Remove(temp);

        }

    }

}
