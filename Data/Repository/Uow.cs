namespace Data.Repository
{
    public class Uow : IUow
    {
        private readonly DataModel _context;
        public ICathedraRepository Cathedra { get; set; }
        public IFacultyRepository Faculty { get; set; }
        public IFlowRepository Flow { get; set; }
        public IGroupRepository Group { get; set; }
        public ISubGroupRepository SubGroup { get; set; }
        public ISubjectInfoBRepository SubjectInfoB { get; set; }
        public ISubjectInfoKRepository SubjectInfoK { get; set; }
        public ITeacherInfoRepository TeacherInfo { get; set; }
        public ISubjectRepository Subject { get; set; }
        public ITeacherLoadRepository TeacherLoad { get; set; }
        public IOtherTypeRepository OtherType { get; set; }
        public ITeacherLoadOtherTypeRepository TeacherLoadOtherType { get; set; }

        public Uow()
        {
            _context = new DataModel();
            Cathedra = new CathedraRepository(_context);
            Faculty = new FacultyRepository(_context);
            Flow = new FlowRepository(_context);
            Group = new GroupRepository(_context);
            SubGroup = new SubGroupRepository(_context);
            SubjectInfoB = new SubjectInfoBRepository(_context);
            SubjectInfoK = new SubjectInfoKRepository(_context);
            TeacherInfo = new TeacherInfoRepository(_context);
            Subject = new SubjectRepository(_context);
            TeacherLoad = new TeacherLoadRepository(_context);
            OtherType = new OtherTypeRepository(_context);
            TeacherLoadOtherType = new TeacherLoadOtherTypeRepository(_context);
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
