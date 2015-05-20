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
    /// Логика взаимодействия для FormSubjectInfoKEdit.xaml
    /// </summary>
    public partial class FormSubjectInfoKEdit : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public SubjectInfoK SubjectInfoK { get; set; }
        private Flow _selectedFlow;
        public FormSubjectInfoKEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormSubjectInfoKEdit(SubjectInfoK subjectInfoK)
            : this()
        {
            SubjectInfoK = subjectInfoK;
        }

        private void FormSubjectInfoKEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.ItemsSource = _uow.Subject.All.ToList();
            ComboBoxSubject.DisplayMemberPath = "Name";
            DataGridFlow.ItemsSource = _uow.Flow.All.ToList();

            if (SubjectInfoK != null)
            {
                TextBoxLectionK.Text = SubjectInfoK.LectionK.ToString();
                TextBoxPracticeK.Text = SubjectInfoK.PracticeK.ToString();
                TextBoxLabK.Text = SubjectInfoK.LabK.ToString();
                TextBoxExamK.Text = SubjectInfoK.ExamK.ToString();
                TextBoxCreditK.Text = SubjectInfoK.CreditK.ToString();
                TextBoxTestK.Text = SubjectInfoK.TestK.ToString();
                TextBoxCourseProjectK.Text = SubjectInfoK.CourseProjectK.ToString();
                TextBoxCourseWorkK.Text = SubjectInfoK.CourseWorkK.ToString();
                TextBoxRgrK.Text = SubjectInfoK.RgrK.ToString();
                TextBoxDkrK.Text = SubjectInfoK.DkrK.ToString();
                TextBoxSummeryK.Text = SubjectInfoK.SummeryK.ToString();
                TextBoxConsultationK.Text = SubjectInfoK.СonsultationK.ToString();
                TextBoxTotalHorseK.Text = SubjectInfoK.TotalHoursK.ToString();
            }
        }

        private void DataGridFlow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedFlow = DataGridFlow.SelectedItem as Flow;
            if (_selectedFlow == null) return;
            int groupCountAcademB = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Бюджет);
            int groupCountAcademK = _selectedFlow.Group.Count(g => g.EducationType == EducationType.Контракт);
            TextBoxAcademB.Text = Convert.ToString(groupCountAcademB);
            TextBoxAcademK.Text = Convert.ToString(groupCountAcademK);
            TextBoxGroupPract.Text = Convert.ToString(groupCountAcademK);
            TextBoxSubGroupLab.Text = Convert.ToString(_selectedFlow.CountSubGroupContract);
            TextBoxStudCountB.Text = Convert.ToString(_selectedFlow.AllCountBudget);
            TextBoxStudCountK.Text = Convert.ToString(_selectedFlow.AllCountContract);

            DataGridSubGroup.ItemsSource = _uow.Flow.Find(_selectedFlow.Id).SubGroup;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SubjectInfoK == null)
                SubjectInfoK = new SubjectInfoK();

            SubjectInfoK.LectionK = Convert.ToInt32(TextBoxLectionK.Text);
            SubjectInfoK.PracticeK = Convert.ToInt32(TextBoxPracticeK.Text);
            SubjectInfoK.LabK = Convert.ToInt32(TextBoxLabK.Text);
            SubjectInfoK.ExamK = Convert.ToDouble(TextBoxExamK.Text);
            SubjectInfoK.CreditK = Convert.ToDouble(TextBoxCreditK.Text);
            SubjectInfoK.TestK = Convert.ToDouble(TextBoxTestK.Text);
            SubjectInfoK.CourseProjectK = Convert.ToInt32(TextBoxCourseProjectK.Text);
            SubjectInfoK.CourseWorkK = Convert.ToInt32(TextBoxCourseWorkK.Text);
            SubjectInfoK.RgrK = Convert.ToDouble(TextBoxRgrK.Text);
            SubjectInfoK.DkrK = Convert.ToDouble(TextBoxDkrK.Text);
            SubjectInfoK.SummeryK = Convert.ToDouble(TextBoxSummeryK.Text);
            SubjectInfoK.СonsultationK = Convert.ToDouble(TextBoxConsultationK.Text);
            SubjectInfoK.TotalHoursK = Convert.ToDouble(TextBoxTotalHorseK.Text);

            var selectedSubject = ComboBoxSubject.SelectedItem as Subject;
            Subject subjectEdit = null;
            if (selectedSubject != null)
            {
                subjectEdit = _uow.Subject.Find(selectedSubject.Id);
                if (subjectEdit.SubjectInfoK == null)
                {
                    subjectEdit.SubjectInfoK = SubjectInfoK;
                    subjectEdit.Flow = _uow.Flow.Find(_selectedFlow.Id);

                    _uow.Subject.InsertOrUpdate(subjectEdit);
                    _uow.Save();
                }
            }

            DialogResult = true;
        }

        private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            int tempStudCountK = Convert.ToInt32(TextBoxStudCountK.Text);

            int lectionV = 0;
            if (_selectedFlow.EduType == EducationType.Контракт)
                lectionV = Convert.ToInt32(TextBoxLectionV.Text);

            int practiceV = Convert.ToInt32(TextBoxPracticeV.Text) * Convert.ToInt32(TextBoxGroupPract.Text);
            int labV = Convert.ToInt32(TextBoxLabV.Text) * Convert.ToInt32(TextBoxSubGroupLab.Text);
            double examV = 0.33 * Convert.ToInt32(TextBoxExamV.Text) * tempStudCountK;

           
            int tempCreditV = Convert.ToInt32(TextBoxCreditV.Text);
            int tempAcademK = Convert.ToInt32(TextBoxAcademK.Text);

            double creditV = 2 * tempAcademK * tempCreditV;
            creditV = Math.Round(creditV, 2);

            double testV = 0.25 * Convert.ToInt32(TextBoxTestV.Text) * tempStudCountK;
            int courseProjectV = Convert.ToInt32(TextBoxCourseProjectV.Text) * tempStudCountK;
            int courseWorkV = Convert.ToInt32(TextBoxCourseWorkV.Text) * tempStudCountK;
            double rgrV = 0.5 * Convert.ToInt32(TextBoxRgrV.Text) * tempStudCountK;
            double dkrV = 0.33 * Convert.ToInt32(TextBoxDkrV.Text) * tempStudCountK;
            double summeryV = 0.25 * Convert.ToInt32(TextBoxSummeryV.Text) * tempStudCountK;

            double consultationV = 0;
            if (_selectedFlow.EduForm == EducationForm.Денна)
            {
                consultationV = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademK +
                                0.06 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountK) / 25;
            }
            else if(_selectedFlow.EduForm == EducationForm.Заочна)
            {
                consultationV = 2 * Convert.ToInt32(TextBoxExamV.Text) * tempAcademK +
                0.12 * Convert.ToInt32(TextBoxAmountHours.Text) * (tempStudCountK) / 25;

            } 
            
            consultationV = Math.Round(consultationV, 2);

            TextBoxLectionK.Text = Convert.ToString(lectionV);
            TextBoxPracticeK.Text = Convert.ToString(practiceV);
            TextBoxLabK.Text = Convert.ToString(labV);
            TextBoxExamK.Text = Convert.ToString(examV);
            TextBoxCreditK.Text = Convert.ToString(creditV);
            TextBoxTestK.Text = Convert.ToString(testV);
            TextBoxCourseProjectK.Text = Convert.ToString(courseProjectV);
            TextBoxCourseWorkK.Text = Convert.ToString(courseWorkV);
            TextBoxRgrK.Text = Convert.ToString(rgrV);
            TextBoxDkrK.Text = Convert.ToString(dkrV);
            TextBoxSummeryK.Text = Convert.ToString(summeryV);
            TextBoxConsultationK.Text = Convert.ToString(consultationV);
            TextBoxTotalHorseK.Text = Convert.ToString(lectionV + practiceV + labV + examV + creditV + testV + courseProjectV + courseWorkV + rgrV + dkrV + summeryV + consultationV);

        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
