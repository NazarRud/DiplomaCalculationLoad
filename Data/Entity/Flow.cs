﻿using System.Collections.Generic;
using Data.Entity.Enum;

namespace Data.Entity
{
    public class Flow
    {
        public Flow()
        {
            this.Subject = new HashSet<Subject>();
            this.SubGroup = new HashSet<SubGroup>();
            this.Group = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AllCountBudget { get; set; }
        public int AllCountContract { get; set; }
        public int CountSubGroupBudget { get; set; }
        public int CountSubGroupContract { get; set; }
        public EducationType EduType { get; set; }
        public EducationForm EduForm { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
        public virtual ICollection<SubGroup> SubGroup { get; set; }
        public virtual ICollection<Group> Group { get; set; }

        //public PracticeManagement PracticeManagement { get; set; }
        //public FlowLoad FlowLoad { get; set; }
        //public AttestationWorkConsultation AttestationWorkConsultation { get; set; }
        //public Tutoring Tutoring { get; set; }
        //public FlowDek FlowDek { get; set; }

    }
}
