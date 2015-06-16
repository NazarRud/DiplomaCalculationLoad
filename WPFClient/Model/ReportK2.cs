using Data.Entity;
using Data.Entity.Enum;

namespace WPFClient.Model
{
    public class ReportK2
    {
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public Course Course { get; set; }
        public EducationForm EducationForm { get; set; }
        public string FlowOrSubGroup { get; set; }
        public TeacherLoad TeacherLoad { get; set; }
        public TeacherLoadOtherType TeacherLoadOtherType { get; set; }
        public double KerPrB { get; set; }
        public double KerPrK { get; set; }
        public double KerBakB { get; set; }
        public double KerBakK { get; set; }
        public double KerSpB { get; set; }
        public double KerSpK { get; set; }
        public double KerMagB { get; set; }
        public double KerMagK { get; set; }
        public double KerAspB { get; set; }
        public double KerAspK { get; set; }
        public double ReB { get; set; }
        public double ReK { get; set; }
        public double WorkB { get; set; }
        public double WorkK { get; set; }
        public double TotalB { get; set; }
        public double TotalC { get; set; }

    }
}
