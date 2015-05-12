using System.Collections.Generic;
using Data.Entity.Enum;

namespace Data.Entity
{
    public class Subject
    {
        public Subject()
        {
            this.TeacherLoad = new HashSet<TeacherLoad>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Semestr Semestr { get; set; }

        public virtual SubjectInfoB SubjectInfoB { get; set; }
        public virtual SubjectInfoK SubjectInfoK { get; set; }
        public virtual Flow Flow { get; set; }

        public virtual ICollection<TeacherLoad> TeacherLoad { get; set; }
    }
}
