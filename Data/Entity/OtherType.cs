using Data.Entity.Enum;

namespace Data.Entity
{
    public class OtherType
    {
        public int Id { get; set; }
        public TypeWork TypeWork { get; set; }
        public SubTypeWork SubTypeWork { get; set; }
        public Semestr Semestr { get; set; }
        public double TotalBudget { get; set; }
        public double TotalContract { get; set; }

        public virtual Flow Flow { get; set; }
    }
}
