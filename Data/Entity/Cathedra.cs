using System.Collections.Generic;

namespace Data.Entity
{
    public class Cathedra
    {
        public Cathedra()
        {
            this.Group = new HashSet<Group>();
            this.TeacherInfo = new HashSet<TeacherInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Group> Group { get; set; }    
        public virtual ICollection<TeacherInfo> TeacherInfo { get; set; }
    }
}
