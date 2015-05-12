using System.Collections.Generic;
using Data.Entity.Enum;

namespace Data.Entity
{
    public class TeacherInfo
    {
        public TeacherInfo()
        {
            this.TeacherLoad = new HashSet<TeacherLoad>();
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public Rank Rank { get; set; }
        public Appointment Appointment { get; set; }
        public Degree Degree { get; set; }
       
        public virtual Cathedra Cathedra { get; set; }

        public virtual ICollection<TeacherLoad> TeacherLoad { get; set; }

    }
}
