using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private List<TeacherInfo> _listTeacherInfos;

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
            Subject = ComboBoxSubject.SelectedItem as Subject;
            //if (selected == null) return;

            //var findSubject = _uow.Subject.Find(selected.Id);
            //DataGridTeacherLoad.ItemsSource = findSubject.TeacherLoad.ToList();
            //DataGridFlow.ItemsSource = (IEnumerable)findSubject.Flow;
            //DataGridSubjectBudget.ItemsSource = findSubject.SubjectInfoB as IEnumerable;
            //DataGridSubjectContract.ItemsSource = findSubject.SubjectInfoK as IEnumerable;
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
            var subjectBudget = Subject.SubjectInfoB; //DataGridSubjectBudget.ItemsSource as SubjectInfoB;
            var subjectContract = Subject.SubjectInfoK; //DataGridSubjectContract.ItemsSource as SubjectInfoK;
            var subject = Subject; //ComboBoxSubject.SelectedItem as Subject;
            var teacherInfo = _listTeacherInfos;
            var count = _listTeacherInfos.Count;

            List<TeacherLoad> teacherLoads = new List<TeacherLoad>();

            TeacherLoad teacherLoad = new TeacherLoad
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
                TeacherInfo = teacherInfo
            };

            teacherLoads.Add(teacherLoad);
            DataGridTeacherLoad.ItemsSource = teacherLoads;
            teacherLoads = null;
        }
    }
}
