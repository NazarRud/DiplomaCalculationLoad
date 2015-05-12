using System.Collections.Generic;

namespace Data.Entity
{
    public class TeacherLoad
    {
        public TeacherLoad()
        {
            this.TeacherInfo = new HashSet<TeacherInfo>();
        }
        public int Id { get; set; }
        public int LectionB { get; set; }
        public int LectionK { get; set; }
        public int PracticeB { get; set; }
        public int PracticeK { get; set; }
        public int LabB { get; set; }
        public int LabK { get; set; }
        public int ExamB { get; set; }
        public int ExamK { get; set; }
        public int CreditB { get; set; }
        public int CreditK { get; set; }
        public int TestB { get; set; }
        public int TestK { get; set; }
        public int CourseProjectB { get; set; }
        public int CourseProjectK { get; set; }
        public int CourseWorkB { get; set; }
        public int CourseWorkK { get; set; }
        public int RgrB { get; set; }
        public int RgrK { get; set; }
        public int DkrB { get; set; }
        public int DkrK { get; set; }
        public int SummeryB { get; set; }
        public int SummeryK { get; set; }
        public int СonsultationB { get; set; }
        public int СonsultationK { get; set; }
        public int TotalHoursB { get; set; }
        public int TotalHoursK { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<TeacherInfo> TeacherInfo { get; set; }
    }
}
