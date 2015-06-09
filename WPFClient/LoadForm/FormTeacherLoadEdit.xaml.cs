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
            int tempStudCountK = Convert.ToInt32(TextBoxStudCountK.Text);
            int tempStudCountBk = Convert.ToInt32(TextBoxStudCountBk.Text);
            int tempStudCountKk = Convert.ToInt32(TextBoxStudCountKk.Text);

            int lectionVb = 0;
            double examVb = 0;
            int practiceVb = 0;
            int labVb = 0;
            int tempCreditVb = 0;
            int tempAcademBb = 0;
            double creditVb = 0;
            double testVb = 0;
            int courseProjectVb = 0;
            int courseWorkVb = 0;
            double rgrVb = 0;
            double dkrVb = 0;
            double summeryVb = 0;
            double consultationVb = 0;

            int lectionVk = 0;
            double examVk = 0;
            int practiceVk = 0;
            int labVk = 0;
            int tempCreditVk = 0;
            int tempAcademKk = 0;
            double creditVk = 0;
            double testVk = 0;
            int courseProjectVk = 0;
            int courseWorkVk = 0;
            double rgrVk = 0;
            double dkrVk = 0;
            double summeryVk = 0;
            double consultationVk = 0;

            tempCreditVb = Convert.ToInt32(TextBoxCreditV.Text);
            tempAcademBb = Convert.ToInt32(TextBoxAcademB.Text);


            if (CheckBoxLector.IsChecked == true || CheckBoxHoursLector.IsChecked == true)
            {
                if (_selectedFlow.EduType == EducationType.Бюджет)
                    lectionVb = Convert.ToInt32(TextBoxLectionV.Text);

                if (_selectedFlow.EduType == EducationType.Контракт)
                    lectionVk = Convert.ToInt32(TextBoxLectionVk.Text);

                examVb = 0.33 * Convert.ToInt32(TextBoxExamV.Text) * tempStudCountB;
                examVk = 0.33 * Convert.ToInt32(TextBoxExamVk.Text) * tempStudCountK;

                creditVb = 2 * tempAcademBb * tempCreditVb;
                creditVb = Math.Round(creditVb, 2);

                creditVk = 2 * tempAcademKk * tempCreditVk;
                creditVk = Math.Round(creditVk, 2);

            }


            if(CheckBoxHoursLector.IsChecked == true || CheckBoxLector.IsChecked == false)
            {
                practiceVb = Convert.ToInt32(TextBoxPracticeV.Text) * Convert.ToInt32(TextBoxSubGroupPract.Text);
                labVb = Convert.ToInt32(TextBoxLabV.Text) * Convert.ToInt32(TextBoxSubGroupLab.Text);

                testVb = 0.25 * Convert.ToInt32(TextBoxTestV.Text) * tempStudCountB;
                courseProjectVb = Convert.ToInt32(TextBoxCourseProjectV.Text) * tempStudCountB;
                courseWorkVb = Convert.ToInt32(TextBoxCourseWorkV.Text) * tempStudCountB;
                rgrVb = 0.5 * Convert.ToInt32(TextBoxRgrV.Text) * tempStudCountB;
                dkrVb = 0.33 * Convert.ToInt32(TextBoxDkrV.Text) * tempStudCountB;
                summeryVb = 0.25 * Convert.ToInt32(TextBoxSummeryV.Text) * tempStudCountB;

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

                //-------------------------------------------------------------------------------------

                practiceVk = Convert.ToInt32(TextBoxPracticeVk.Text) * Convert.ToInt32(TextBoxSubGroupPractk.Text);
                labVk = Convert.ToInt32(TextBoxLabVk.Text) * Convert.ToInt32(TextBoxSubGroupLabk.Text);


                tempCreditVk = Convert.ToInt32(TextBoxCreditVk.Text);
                tempAcademKk = Convert.ToInt32(TextBoxAcademKk.Text);


                testVk = 0.25 * Convert.ToInt32(TextBoxTestVk.Text) * tempStudCountKk;
                courseProjectVk = Convert.ToInt32(TextBoxCourseProjectVk.Text) * tempStudCountKk;
                courseWorkVk = Convert.ToInt32(TextBoxCourseWorkVk.Text) * tempStudCountKk;
                rgrVk = 0.5 * Convert.ToInt32(TextBoxRgrVk.Text) * tempStudCountKk;
                dkrVk = 0.33 * Convert.ToInt32(TextBoxDkrVk.Text) * tempStudCountKk;
                summeryVk = 0.25 * Convert.ToInt32(TextBoxSummeryVk.Text) * tempStudCountKk;

                if (_selectedFlow.EduForm == EducationForm.Денна)
                {
                    consultationVk = 2 * Convert.ToInt32(TextBoxExamVk.Text) * tempAcademKk +
                                    0.06 * Convert.ToInt32(TextBoxAmountHoursK.Text) * (tempStudCountKk) / 25;
                }
                else if (_selectedFlow.EduForm == EducationForm.Заочна)
                {
                    consultationVk = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademKk +
                    0.12 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountKk) / 25;

                }

                consultationVk = Math.Round(consultationVk, 2);
            }

            double totalHorseB = lectionVb + practiceVb + labVb + examVb + creditVb + testVb + courseProjectVb + courseWorkVb + rgrVb + dkrVb + summeryVb + consultationVb;
            double totalHourseK = lectionVk + practiceVk + labVk + examVk + creditVk + testVk + courseProjectVk + courseWorkVk + rgrVk + dkrVk + summeryVk + consultationVk;

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

            TotalLekB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.LectionB));
            TotalLekK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.LectionK));
            TotalPracticeB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.PracticeB));
            TotalPracticeK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.PracticeK));
            TotalLabB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.LabB));
            TotalLabK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.LabK));
            TotalExamB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.ExamB));
            TotalExamK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.ExamK));
            TotalCreditB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CreditB));
            TotalCreditK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CreditK));
            TotalTestB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.TestB));
            TotalTestK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.TestK));
            TotalCourseProjectB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CourseProjectB));
            TotalCourseProjectK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CourseProjectK));
            TotalCourseWorkB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CourseWorkB));
            TotalCourseWorkK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.CourseWorkK));
            TotalRgrB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.RgrB));
            TotalRgrK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.RgrK));
            TotalDkrB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.DkrB));
            TotalDkrK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.DkrK));
            TotalSummeryB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.SummeryB));
            TotalSummeryK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.SummeryK));
            TotalСonsultationB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.СonsultationB));
            TotalСonsultationK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.СonsultationK));
            TotalTotalHoursB.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.TotalHoursB));
            TotalTotalHoursK.Text = Convert.ToString(_listTeacherLoad.Sum(l => l.TotalHoursK));


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
