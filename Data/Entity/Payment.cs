using System.Collections.Generic;
using Data.Entity.Enum;

namespace Data.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string AppointmentSub { get; set; }
        public int Salary { get; set; }
        
        public virtual ICollection<PaymentForYears> PaymentForYearses { get; set; }
    }
}
