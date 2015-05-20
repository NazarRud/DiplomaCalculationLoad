using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormSubjectInfoEdit.xaml
    /// </summary>
    public partial class FormSubjectInfoEdit : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        private Flow _selectedFlow;
        public SubjectInfoB SubjectInfoB { get; set; }
        public FormSubjectInfoEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormSubjectInfoEdit(SubjectInfoB subjectInfo)
            : this()
        {
            SubjectInfoB = subjectInfo;
        }

        private void FormSubjectInfoEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridFlow.ItemsSource = _uow.Flow.All.ToList();
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";

            if (SubjectInfoB != null)
            {
                TextBoxLectionB.Text = SubjectInfoB.LectionB.ToString();
                TextBoxPracticeB.Text = SubjectInfoB.PracticeB.ToString();
                TextBoxLabB.Text = SubjectInfoB.LabB.ToString();
                TextBoxExamB.Text = SubjectInfoB.ExamB.ToString();
                TextBoxCreditB.Text = SubjectInfoB.CreditB.ToString();
                TextBoxTestB.Text = SubjectInfoB.TestB.ToString();
                TextBoxCourseProjectB.Text = SubjectInfoB.CourseProjectB.ToString();
                TextBoxCourseWorkB.Text = SubjectInfoB.CourseWorkB.ToString();
                TextBoxRgrB.Text = SubjectInfoB.RgrB.ToString();
                TextBoxDkrB.Text = SubjectInfoB.DkrB.ToString();
                TextBoxSummeryB.Text = SubjectInfoB.SummeryB.ToString();
                TextBoxConsultationB.Text = SubjectInfoB.СonsultationB.ToString();
                TextBoxTotalHorseB.Text = SubjectInfoB.TotalHoursB.ToString();
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SubjectInfoB == null)
                SubjectInfoB = new SubjectInfoB();

            SubjectInfoB.LectionB = Convert.ToInt32(TextBoxLectionB.Text);
            SubjectInfoB.PracticeB = Convert.ToInt32(TextBoxPracticeB.Text);
            SubjectInfoB.LabB = Convert.ToInt32(TextBoxLabB.Text);
            SubjectInfoB.ExamB = Convert.ToDouble(TextBoxExamB.Text);
            SubjectInfoB.CreditB = Convert.ToDouble(TextBoxCreditB.Text);
            SubjectInfoB.TestB = Convert.ToDouble(TextBoxTestB.Text);
            SubjectInfoB.CourseProjectB = Convert.ToInt32(TextBoxCourseProjectB.Text);
            SubjectInfoB.CourseWorkB = Convert.ToInt32(TextBoxCourseWorkB.Text);
            SubjectInfoB.RgrB = Convert.ToDouble(TextBoxRgrB.Text);
            SubjectInfoB.DkrB = Convert.ToDouble(TextBoxDkrB.Text);
            SubjectInfoB.SummeryB = Convert.ToDouble(TextBoxSummeryB.Text);
            SubjectInfoB.СonsultationB = Convert.ToDouble(TextBoxConsultationB.Text);
            SubjectInfoB.TotalHoursB = Convert.ToDouble(TextBoxTotalHorseB.Text);

            var selectedSubject = ComboBoxSubject.SelectedItem as Subject;
            Subject subjectEdit = null;
            if (selectedSubject != null)
            {
                subjectEdit = _uow.Subject.Find(selectedSubject.Id);
                if (subjectEdit.SubjectInfoB == null)
                {
                    subjectEdit.SubjectInfoB = SubjectInfoB;
                    subjectEdit.Flow = _uow.Flow.Find(_selectedFlow.Id);
                    _uow.Subject.InsertOrUpdate(subjectEdit);
                    _uow.Save();
                }
            }

            DialogResult = true;

        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DataGridFlow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedFlow = DataGridFlow.SelectedItem as Flow;
            if (_selectedFlow == null) return;
            int groupCountAcademB = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Бюджет);
            int groupCountAcademK = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Контракт);
            TextBoxAcademB.Text = Convert.ToString(groupCountAcademB);
            TextBoxAcademK.Text = Convert.ToString(groupCountAcademK);
            TextBoxGroupPract.Text = Convert.ToString(groupCountAcademB);
            TextBoxSubGroupLab.Text = Convert.ToString(_selectedFlow.CountSubGroupBudget);
            TextBoxStudCountB.Text = _selectedFlow.AllCountBudget.ToString();
            TextBoxStudCountK.Text = Convert.ToString(_selectedFlow.AllCountContract);

            DataGridSubGroup.ItemsSource = _uow.Flow.Find(_selectedFlow.Id).SubGroup;
        }

        private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            int tempStudCountB = Convert.ToInt32(TextBoxStudCountB.Text);

            int lectionV = 0;
            if (_selectedFlow.EduType == EducationType.Бюджет)
                lectionV = Convert.ToInt32(TextBoxLectionV.Text);

            int practiceV = Convert.ToInt32(TextBoxPracticeV.Text) * Convert.ToInt32(TextBoxGroupPract.Text);
            int labV = Convert.ToInt32(TextBoxLabV.Text) * Convert.ToInt32(TextBoxSubGroupLab.Text);
            double examV = 0.33 * Convert.ToInt32(TextBoxExamV.Text) * tempStudCountB;
            
            int tempCreditV = Convert.ToInt32(TextBoxCreditV.Text);
            int tempAcademB = Convert.ToInt32(TextBoxAcademB.Text);

            double creditV = 2 * tempAcademB * tempCreditV;
            creditV = Math.Round(creditV, 2);
         

            double testV = 0.25 * Convert.ToInt32(TextBoxTestV.Text) * tempStudCountB;
            int courseProjectV = Convert.ToInt32(TextBoxCourseProjectV.Text) * tempStudCountB;
            int courseWorkV = Convert.ToInt32(TextBoxCourseWorkV.Text) * tempStudCountB;
            double rgrV = 0.5 * Convert.ToInt32(TextBoxRgrV.Text) * tempStudCountB;
            double dkrV = 0.33 * Convert.ToInt32(TextBoxDkrV.Text) * tempStudCountB;
            double summeryV = 0.25 * Convert.ToInt32(TextBoxSummeryV.Text) * tempStudCountB;

            double consultationV = 0;
            if (_selectedFlow.EduForm == EducationForm.Денна)
            {
                consultationV = 2*Convert.ToInt32(TextBoxExamV.Text)*tempAcademB +
                                0.06*Convert.ToInt32(TextBoxAmountHours.Text)*(tempStudCountB)/25;
            }
            else if(_selectedFlow.EduForm == EducationForm.Заочна)
            {
                consultationV = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademB +
                0.12 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountB) / 25;

            }

            consultationV = Math.Round(consultationV, 2);

            TextBoxLectionB.Text = Convert.ToString(lectionV);
            TextBoxPracticeB.Text = Convert.ToString(practiceV);
            TextBoxLabB.Text = Convert.ToString(labV);
            TextBoxExamB.Text = Convert.ToString(examV);
            TextBoxCreditB.Text = Convert.ToString(creditV);
            TextBoxTestB.Text = Convert.ToString(testV);
            TextBoxCourseProjectB.Text = Convert.ToString(courseProjectV);
            TextBoxCourseWorkB.Text = Convert.ToString(courseWorkV);
            TextBoxRgrB.Text = Convert.ToString(rgrV);
            TextBoxDkrB.Text = Convert.ToString(dkrV);
            TextBoxSummeryB.Text = Convert.ToString(summeryV);
            TextBoxConsultationB.Text = Convert.ToString(consultationV);
            TextBoxTotalHorseB.Text = Convert.ToString(lectionV + practiceV + labV + examV + creditV + testV + courseProjectV + courseWorkV + rgrV + dkrV + summeryV + consultationV);
        }
    }
}
