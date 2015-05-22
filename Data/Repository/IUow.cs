using System;

namespace Data.Repository
{
    public interface IUow : IDisposable
    {
        ICathedraRepository Cathedra { get; set; }
        IFacultyRepository Faculty { get; set; }
        IFlowRepository Flow { get; set; }
        IGroupRepository Group { get; set; }
        ISubGroupRepository SubGroup { get; set; }
        ISubjectInfoBRepository SubjectInfoB { get; set; }
        ISubjectInfoKRepository SubjectInfoK { get; set; }
        ITeacherInfoRepository TeacherInfo { get; set; }
        ISubjectRepository Subject { get; set; }
        ITeacherLoadRepository TeacherLoad { get; set; }
        IOtherTypeRepository OtherType { get; set; }
        void Save();
    }
}
