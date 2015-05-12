using System.Collections.Generic;
using Data.Entity.Enum;

namespace Data.Entity
{
    public class Group
    {
        public Group()
        {
            this.Flow = new HashSet<Flow>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCountBudget { get; set; }
        public int StudentsCountContract { get; set; }
        public int StudentsCountTotal { get; set; }
        public QualificationLevel QualificationLevel { get; set; }
        public EducationForm EducationForm { get; set; }
        public EducationType EducationType { get; set; }
        public Course Course { get; set; }

        public virtual ICollection<Flow> Flow { get; set; }
        public virtual Cathedra Cathedra { get; set; }
    }
}
