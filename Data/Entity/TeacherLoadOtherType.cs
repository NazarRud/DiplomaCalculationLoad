using System.Collections.Generic;

namespace Data.Entity
{
    public class TeacherLoadOtherType
    {
      
        public int Id { get; set; }

        public int CountStudentB { get; set; }
        public int CountStudentK { get; set; }
        public double CountHoursB { get; set; }
        public double CountHoursC { get; set; }
        public double Total { get; set; }

        public virtual TeacherInfo TeacherInfo { get; set; }
        public virtual OtherType OtherType { get; set; }
    }
}
