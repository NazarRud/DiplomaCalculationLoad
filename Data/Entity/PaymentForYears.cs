using Data.Entity.Enum;

namespace Data.Entity
{
    public class PaymentForYears
    {
        public int Id { get; set; }
        public YearsCount YearsCount { get; set; }
        public int Allowance { get; set; }
        public int Percentage { get; set; }
        public virtual Payment Payment { get; set; }

    }
}
