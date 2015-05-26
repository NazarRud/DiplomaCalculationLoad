using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoadOtherTypeEdit.xaml
    /// </summary>
    public partial class FormTeacherLoadOtherTypeEdit : Window
    {
        private IUow _uow;
        private readonly App _app = Application.Current as App;
        public TeacherLoadOtherType TeacherLoadOtherType { get; set; }

        private List<TeacherInfo> teacherInfos;
        private List<OtherType> otherTypes; 

        public FormTeacherLoadOtherTypeEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();

            teacherInfos = new List<TeacherInfo>();
            otherTypes = new List<OtherType>();
        }

        private void FormTeacherLoadOtherTypeEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTeacher.ItemsSource = _uow.TeacherInfo.All.ToList();
            ComboBoxTeacher.DisplayMemberPath = "Initials";
            DataGridOtherType.ItemsSource = _uow.OtherType.All.ToList();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CalculationButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tempList = new List<TeacherLoadOtherType>();
            int length = 0;

            if (teacherInfos.Count >= otherTypes.Count)
            {
                length = teacherInfos.Count;
            }
            else if(otherTypes.Count >= teacherInfos.Count)
            {
                length = otherTypes.Count;
            }

            //int T = Convert.ToInt32(TextBoxCountWeek.Text);
            //int G = Convert.ToInt32(TextBoxCountBudgetGroup.Text);
            //int GK = Convert.ToInt32(TextBoxCountContractGroup.Text);
            //int DG = Convert.ToInt32(TextBoxCountSubject.Text);
            //int d = Convert.ToInt32(TextBoxCountDek.Text);
            //int N = Convert.ToInt32(TextBoxScopeSubject.Text);
            //int countAspDok = Convert.ToInt32(TextBoxCountHoursAspDok.Text);
            //int countHoursExam = Convert.ToInt32(TextBoxCountHoursExam.Text);

            double sumHoursB = otherTypes.Sum(type => type.TotalBudget)/length;
            double sumHourseK = otherTypes.Sum(type => type.TotalContract)/length;
            int sumStudB = otherTypes.Sum(type => type.Flow.AllCountBudget)/length;
            int sumStudK = otherTypes.Sum(type => type.Flow.AllCountContract)/length;
    
            for (int i = 0; i < length; i++)
            {               
                var teacherLoadOtherType = new TeacherLoadOtherType
                {
                    CountStudentB = sumStudB,
                    CountStudentK = sumStudK,
                    CountHoursB = sumHoursB,
                    CountHourseC = sumHourseK,
                    Total = sumHoursB + sumHourseK,
                    TeacherInfo = teacherInfos[i],
                    OtherType = otherTypes[i]
                };
                tempList.Add(teacherLoadOtherType);
            }

            DataGridTeacherLoadOtherType.ItemsSource = tempList;

        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxTeacher_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = ComboBoxTeacher.SelectedItem as TeacherInfo;
            if(selectedTeacher == null) return;

            teacherInfos.Add(selectedTeacher);

            ListBoxTeacher.ItemsSource = teacherInfos;
        }

        private void DataGridOtherType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = DataGridOtherType.SelectedItem as OtherType;
            if(selectedTeacher == null) return;

            otherTypes.Add(selectedTeacher);
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            teacherInfos.RemoveAll(i => i.Id >= 0);
            otherTypes.RemoveAll(i => i.Id >= 0);
            ListBoxTeacher = null;
        }

        //private int[] GetValues()
        //{
        //    var arr = new int[10];

        //    int T = Convert.ToInt32(TextBoxCountWeek.Text);
        //    int G = Convert.ToInt32(TextBoxCountBudgetGroup.Text);
        //    int GK = Convert.ToInt32(TextBoxCountContractGroup.Text);
        //    int DG = Convert.ToInt32(TextBoxCountSubject.Text);
        //    int d = Convert.ToInt32(TextBoxCountDek.Text);
        //    int N = Convert.ToInt32(TextBoxScopeSubject.Text);
        //    int countAspDok = Convert.ToInt32(TextBoxCountHoursAspDok.Text);
        //    int countHoursExam = Convert.ToInt32(TextBoxCountHoursExam.Text);
        //}
    }
}
