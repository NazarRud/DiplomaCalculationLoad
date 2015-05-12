using System.Data.Entity;
using Data.Entity;

namespace Data
{
    public class DataModel : DbContext
    {
        //static DataModel()
        //{
        //    Database.SetInitializer(new DropCreateDatabaseAlways<DataModel>());
        //}
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Cathedra> Cathedras { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfos { get; set; }
        public virtual DbSet<Flow> Flows { get; set; }
        public virtual DbSet<SubGroup> SubGroups { get; set; }
        public virtual DbSet<SubjectInfoB> SubjectInfosBs { get; set; }
        public virtual DbSet<SubjectInfoK> SubjectInfosKs { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeacherLoad> TeacherLoads { get; set; }
    }
}