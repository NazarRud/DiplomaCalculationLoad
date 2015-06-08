using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
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
        public List<TeacherLoad> ListTeacherLoads { get; set; }
        private Flow _selectedFlow;
        private readonly List<TeacherLoad> _listTeacherLoad = new List<TeacherLoad>();
        public FormTeacherLoadEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormTeacherLoadEdit(List<TeacherLoad> teacherLoads) : this()
        {
            ListTeacherLoads = teacherLoads;
        }

        private void FormTeacherLoadEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";
            ComboBoxTeacher.ItemsSource = _uow.TeacherInfo.All.ToList();
            ComboBoxTeacher.DisplayMemberPath = "Initials";

            if (ListTeacherLoads != null)
                DataGridTeacherLoad.ItemsSource = ListTeacherLoads;

        }

        private void ComboBoxSubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxSubject.SelectedItem as Subject;
            if (selected == null) return;

            var findSubject = _uow.Subject.Find(selected.Id);

            if(findSubject.TeacherLoad != null)
                DataGridTeacherLoad.ItemsSource = findSubject.TeacherLoad.ToList();

            if (findSubject.Flow != null)
            {
                DataGridFlow.ItemsSource = new List<Flow> { findSubject.Flow };
                DataGridSubGroup.ItemsSource = findSubject.Flow.SubGroup;
            }

            if(findSubject.SubjectInfoB != null)
                DataGridSubjectBudget.ItemsSource = new List<SubjectInfoB> {findSubject.SubjectInfoB};

            if(findSubject.SubjectInfoK != null)
                DataGridSubjectContract.ItemsSource = new List<SubjectInfoK> {findSubject.SubjectInfoK};
 
        }

        private void ComboBoxTeacher_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxTeacher.SelectedItem as TeacherInfo;
            if(selected == null) return;
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            

            var subject = ComboBoxSubject.SelectedItem as Subject;
            var teacher = ComboBoxTeacher.SelectedItem as TeacherInfo;
            var subGroup = DataGridSubGroup.SelectedItem as SubGroup;

            int tempStudCountB = Convert.ToInt32(TextBoxStudCountB.Text);

            int lectionVb = 0;
            if (_selectedFlow.EduType == EducationType.Бюджет)
                lectionVb = Convert.ToInt32(TextBoxLectionV.Text);

            int practiceVb = Convert.ToInt32(TextBoxPracticeV.Text) * Convert.ToInt32(TextBoxSubGroupPract.Text);
            int labVb = Convert.ToInt32(TextBoxLabV.Text) * Convert.ToInt32(TextBoxSubGroupLab.Text);
            double examVb = 0.33 * Convert.ToInt32(TextBoxExamV.Text) * tempStudCountB;

            int tempCreditVb = Convert.ToInt32(TextBoxCreditV.Text);
            int tempAcademBb = Convert.ToInt32(TextBoxAcademB.Text);

            double creditVb = 2 * tempAcademBb * tempCreditVb;
            creditVb = Math.Round(creditVb, 2);


            double testVb = 0.25 * Convert.ToInt32(TextBoxTestV.Text) * tempStudCountB;
            int courseProjectVb = Convert.ToInt32(TextBoxCourseProjectV.Text) * tempStudCountB;
            int courseWorkVb = Convert.ToInt32(TextBoxCourseWorkV.Text) * tempStudCountB;
            double rgrVb = 0.5 * Convert.ToInt32(TextBoxRgrV.Text) * tempStudCountB;
            double dkrVb = 0.33 * Convert.ToInt32(TextBoxDkrV.Text) * tempStudCountB;
            double summeryVb = 0.25 * Convert.ToInt32(TextBoxSummeryV.Text) * tempStudCountB;

            double consultationVb = 0;
            if (_selectedFlow.EduForm == EducationForm.Денна)
            {
                consultationVb = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademBb +
                                0.06 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountB) / 25;
            }
            else if (_selectedFlow.EduForm == EducationForm.Заочна)
            {
                consultationVb = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademBb +
                0.12 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountB) / 25;

            }

            consultationVb = Math.Round(consultationVb, 2);
           
            double totalHorseB = lectionVb + practiceVb + labVb + examVb + creditVb + testVb + courseProjectVb + courseWorkVb + rgrVb + dkrVb + summeryVb + consultationVb;
            
            //------------------------------------------------------------------------------------------

            int tempStudCountK = Convert.ToInt32(TextBoxStudCountK.Text);

            int lectionVk = 0;
            if (_selectedFlow.EduType == EducationType.Контракт)
                lectionVk = Convert.ToInt32(TextBoxLectionVk.Text);

            int practiceVk = Convert.ToInt32(TextBoxPracticeVk.Text) * Convert.ToInt32(TextBoxSubGroupPractk.Text);
            int labVk = Convert.ToInt32(TextBoxLabVk.Text) * Convert.ToInt32(TextBoxSubGroupLabk.Text);
            double examVk = 0.33 * Convert.ToInt32(TextBoxExamVk.Text) * tempStudCountK;


            int tempCreditVk = Convert.ToInt32(TextBoxCreditVk.Text);
            int tempAcademKk = Convert.ToInt32(TextBoxAcademKk.Text);

            double creditVk = 2 * tempAcademKk * tempCreditVk;
            creditVk = Math.Round(creditVk, 2);

            double testVk = 0.25 * Convert.ToInt32(TextBoxTestVk.Text) * tempStudCountK;
            int courseProjectVk = Convert.ToInt32(TextBoxCourseProjectVk.Text) * tempStudCountK;
            int courseWorkVk = Convert.ToInt32(TextBoxCourseWorkVk.Text) * tempStudCountK;
            double rgrVk = 0.5 * Convert.ToInt32(TextBoxRgrVk.Text) * tempStudCountK;
            double dkrVk = 0.33 * Convert.ToInt32(TextBoxDkrVk.Text) * tempStudCountK;
            double summeryVk = 0.25 * Convert.ToInt32(TextBoxSummeryVk.Text) * tempStudCountK;

            double consultationVk = 0;
            if (_selectedFlow.EduForm == EducationForm.Денна)
            {
                consultationVk = 2 * Convert.ToInt32(TextBoxExamVk.Text) * tempAcademKk +
                                0.06 * Convert.ToInt32(TextBoxAmountHoursK.Text) * (tempStudCountK) / 25;
            }
            else if (_selectedFlow.EduForm == EducationForm.Заочна)
            {
                consultationVk = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademKk +
                0.12 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountK) / 25;

            }

            consultationVk = Math.Round(consultationVk, 2);

            double totalHourseK = lectionVk + practiceVk + labVk + examVk + creditVk + testVk + courseProjectVk + courseWorkVk + rgrVk + dkrVk + summeryVk + consultationVk;


            //------------------------------------------------------------------------------------------

            var teampTeacherLoad = new TeacherLoad
            {
                LectionB = lectionVb,
                LectionK = lectionVk,
                PracticeB = practiceVb,
                PracticeK = practiceVk,
                LabB = labVb,
                LabK = labVk,
                ExamB = examVb,
                ExamK = examVk,
                CreditB = creditVb,
                CreditK = creditVk,
                TestB = testVb,
                TestK = testVk,
                CourseProjectB = courseProjectVb,
                CourseProjectK = courseProjectVk,
                CourseWorkB = courseWorkVb,
                CourseWorkK = courseWorkVk,
                RgrB = rgrVb,
                RgrK = rgrVk,
                DkrB = dkrVb,
                DkrK = dkrVk,
                SummeryB = summeryVb,
                SummeryK = summeryVk,
                СonsultationB = consultationVb,
                СonsultationK = consultationVk,
                TotalHoursB = totalHorseB,
                TotalHoursK = totalHourseK,
                TotalHourse = totalHorseB + totalHourseK,
                Subject = subject,
                TeacherInfo = teacher,
                SubGroup = subGroup
            };

            _listTeacherLoad.Add(teampTeacherLoad);

            DataGridTeacherLoad.ItemsSource = null;
            DataGridTeacherLoad.ItemsSource = _listTeacherLoad;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var gridTeacherLoad = DataGridTeacherLoad.ItemsSource as IEnumerable<TeacherLoad>;

            if (ListTeacherLoads == null)
                ListTeacherLoads = new List<TeacherLoad>();

            if (gridTeacherLoad != null)
                foreach (var item in gridTeacherLoad)
                {
                    TeacherLoad teacherLoad = item;
                    ListTeacherLoads.Add(teacherLoad);
                }

            DialogResult = true;
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ClearDataGridTeacherLoadButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataGridTeacherLoad.ItemsSource = null;
            _listTeacherLoad.RemoveAll(t => t.Id >= 0);
        }

        private void CalculationHoursButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tempList = new List<TeacherLoad>();
            var listTeacherLoad = DataGridTeacherLoad.ItemsSource as List<TeacherLoad>;
            if(listTeacherLoad != null)
            foreach (var load in listTeacherLoad)
            {
                load.TotalHoursB = load.LectionB + load.PracticeB + load.LabB + load.ExamB + load.CreditB + load.TestB +
                                   load.CourseProjectB + load.RgrB + load.DkrB + load.SummeryB + load.СonsultationB;
                load.TotalHoursK = load.LectionK + load.PracticeK + load.LabK + load.ExamK + load.CreditK + load.TestK +
                                   load.CourseProjectK + load.RgrK + load.DkrK + load.SummeryK + load.СonsultationK;

                load.TotalHourse = load.TotalHoursB + load.TotalHoursK;

                tempList.Add(load);
            }

            DataGridTeacherLoad.ItemsSource = tempList;
        }

        private void DataGridFlow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedFlow = DataGridFlow.SelectedItem as Flow;
            if (_selectedFlow == null) return;

            int groupCountAcademB = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Бюджет);
            int groupCountAcademK = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Контракт);

            TextBoxAcademB.Text = Convert.ToString(groupCountAcademB);
            TextBoxAcademK.Text = Convert.ToString(groupCountAcademK);
            TextBoxSubGroupPract.Text = Convert.ToString(_selectedFlow.CountSubGroupBudget);
            TextBoxSubGroupLab.Text = Convert.ToString(_selectedFlow.CountSubGroupBudget);
            TextBoxStudCountB.Text = _selectedFlow.AllCountBudget.ToString();
            TextBoxStudCountK.Text = Convert.ToString(_selectedFlow.AllCountContract);

            TextBoxAcademBk.Text = Convert.ToString(groupCountAcademB);
            TextBoxAcademKk.Text = Convert.ToString(groupCountAcademK);
            TextBoxSubGroupPractk.Text = Convert.ToString(_selectedFlow.CountSubGroupContract);
            TextBoxSubGroupLabk.Text = Convert.ToString(_selectedFlow.CountSubGroupContract);
            TextBoxStudCountBk.Text = Convert.ToString(_selectedFlow.AllCountBudget);
            TextBoxStudCountKk.Text = Convert.ToString(_selectedFlow.AllCountContract);
        }
    }
}
