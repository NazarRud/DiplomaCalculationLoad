using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoadEdit.xaml
    /// </summary>
    public partial class FormTeacherLoadEdit : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public TeacherLoad TeacherLoad { get; set; }
        public Subject Subject { get; set; }
        private readonly List<TeacherInfo> _listTeacherInfos;

        public FormTeacherLoadEdit()
        {
            if (_app != null) _uow = _app.Uow;
            _listTeacherInfos = new List<TeacherInfo>();
            InitializeComponent();
        }

        public FormTeacherLoadEdit(Subject subject) : this()
        {
            Subject = subject;
        }

        private void FormTeacherLoadEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";
            ComboBoxTeacher.ItemsSource = _uow.TeacherInfo.All.ToList();
            ComboBoxTeacher.DisplayMemberPath = "Initials";

            if (Subject != null)
                DataGridTeacherLoad.ItemsSource = Subject.TeacherLoad.ToList();

        }

        private void ComboBoxSubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxSubject.SelectedItem as Subject;
            if (selected == null) return;

            var findSubject = _uow.Subject.Find(selected.Id);
            DataGridTeacherLoad.ItemsSource = findSubject.TeacherLoad.ToList();

            DataGridFlow.ItemsSource = new List<Flow> {findSubject.Flow};
            DataGridSubjectBudget.ItemsSource = new List<SubjectInfoB> {findSubject.SubjectInfoB};
            DataGridSubjectContract.ItemsSource = new List<SubjectInfoK> {findSubject.SubjectInfoK};
        }

        private void ComboBoxTeacher_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxTeacher.SelectedItem as TeacherInfo;
            if(selected == null) return;

            _listTeacherInfos.Add(selected);

            TeacherListBox.ItemsSource = null;
            TeacherListBox.ItemsSource = _listTeacherInfos;
            TeacherListBox.DisplayMemberPath = "Initials";
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var subjectBudget = new SubjectInfoB();
            var subjectContract = new SubjectInfoK();
            var listTeacherLoad = new List<TeacherLoad>();

            var sBiEnum = DataGridSubjectBudget.ItemsSource as IEnumerable<SubjectInfoB>;
            var sCiEnum = DataGridSubjectContract.ItemsSource as IEnumerable<SubjectInfoK>;

            if (sBiEnum != null && sCiEnum != null)
            {
                foreach (var infoB in sBiEnum)
                {
                    subjectBudget = infoB;
                }

                foreach (var infoC in sCiEnum)
                {
                    subjectContract = infoC;
                }
            }
            //var totalHoursB = subjectBudget.TotalHoursB;
            //var totalHourseK = subjectContract.TotalHoursK;
            var subject = ComboBoxSubject.SelectedItem as Subject;

            var count = _listTeacherInfos.Count;

            for (int i = 0; i < count; i++)
            {
                var teacherLoad = new TeacherLoad
                {
                    LectionB = subjectBudget.LectionB / count,
                    LectionK = subjectContract.LectionK / count,
                    PracticeB = subjectBudget.PracticeB / count,
                    PracticeK = subjectContract.PracticeK / count,
                    LabB = subjectBudget.LabB / count,
                    LabK = subjectContract.LabK / count,
                    ExamB = subjectBudget.ExamB / count,
                    ExamK = subjectContract.ExamK / count,
                    CreditB = subjectBudget.CreditB / count,
                    CreditK = subjectContract.CreditK / count,
                    TestB = subjectBudget.TestB / count,
                    TestK = subjectContract.TestK / count,
                    CourseProjectB = subjectBudget.CourseProjectB / count,
                    CourseProjectK = subjectContract.CourseProjectK / count,
                    CourseWorkB = subjectBudget.CourseWorkB / count,
                    CourseWorkK = subjectContract.CourseWorkK / count,
                    RgrB = subjectBudget.RgrB / count,
                    RgrK = subjectContract.RgrK / count,
                    DkrB = subjectBudget.DkrB / count,
                    DkrK = subjectContract.DkrK / count,
                    SummeryB = subjectBudget.SummeryB / count,
                    SummeryK = subjectContract.SummeryK / count,
                    СonsultationB = subjectBudget.СonsultationB / count,
                    СonsultationK = subjectContract.СonsultationK / count,
                    TotalHoursB = subjectBudget.TotalHoursB / count,
                    TotalHoursK = subjectContract.TotalHoursK / count,
                    TotalHourse = (subjectBudget.TotalHoursB + subjectContract.TotalHoursK) / count,
                    Subject = subject,
                    TeacherInfo = _listTeacherInfos[i]
                };

                listTeacherLoad.Add(teacherLoad);
            }

           

            DataGridTeacherLoad.ItemsSource = listTeacherLoad;
        }
    }
}
