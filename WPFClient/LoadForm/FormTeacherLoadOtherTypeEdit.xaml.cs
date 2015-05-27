using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;
using WPFClient.CalculateTypeWork;

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

        private readonly List<TeacherInfo> _teacherInfos;
        private readonly List<OtherType> _otherTypes;
        private readonly List<TeacherLoadOtherType> _tempList;

        public FormTeacherLoadOtherTypeEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();

            _teacherInfos = new List<TeacherInfo>();
            _otherTypes = new List<OtherType>();
            _tempList = new List<TeacherLoadOtherType>();
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
            if(_teacherInfos == null || _otherTypes == null || _tempList == null) return;

            int lengthTecher = _teacherInfos.Count;
            //int lengthOtherType = _otherTypes.Count;

            double sumHoursB = _otherTypes.Sum(type => type.TotalBudget) / lengthTecher;
            double sumHourseK = _otherTypes.Sum(type => type.TotalContract) / lengthTecher;
            int sumStudB = _otherTypes.Sum(type => type.Flow.AllCountBudget) / lengthTecher;
            int sumStudK = _otherTypes.Sum(type => type.Flow.AllCountContract) / lengthTecher;
    
            for (int i = 0; i < lengthTecher; i++)
            {
                var tempLoad = new TeacherLoadOtherType
                {
                    CountStudentB = sumStudB,
                    CountStudentK = sumStudK,
                    CountHoursB = sumHoursB,
                    CountHoursC = sumHourseK,
                    Total = sumHoursB + sumHourseK,
                    TeacherInfo = _teacherInfos[i],
                    OtherType = DataGridOtherType.SelectedItem as OtherType
                };

                _tempList.Add(tempLoad);
            }

            DataGridTeacherLoadOtherType.ItemsSource = null;
            DataGridTeacherLoadOtherType.ItemsSource = _tempList;
            _otherTypes.RemoveAll(i => i.Id >= 0);

        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            int T = Convert.ToInt32(TextBoxCountWeek.Text);
            int G = Convert.ToInt32(TextBoxCountBudgetGroup.Text);
            int GK = Convert.ToInt32(TextBoxCountContractGroup.Text);
            int DG = Convert.ToInt32(TextBoxCountSubject.Text);
            int d = Convert.ToInt32(TextBoxCountDek.Text);
            int N = Convert.ToInt32(TextBoxScopeSubject.Text);
            int countAspDok = Convert.ToInt32(TextBoxCountHoursAspDok.Text);
            int countHoursExam = Convert.ToInt32(TextBoxCountHoursExam.Text);

            var load = DataGridTeacherLoadOtherType.ItemsSource as List<TeacherLoadOtherType>;
            if(load == null) return;

            List< TeacherLoadOtherType> loadList = new List<TeacherLoadOtherType>();

            foreach (var loadOtherType in load)
            {
                double[] arr = CalculateOtherType.Calculate(loadOtherType.OtherType.TypeWork,loadOtherType.OtherType.SubTypeWork, loadOtherType.CountStudentB, loadOtherType.CountStudentK, countHoursExam, countAspDok, T, N, G, GK, DG, d);
                loadOtherType.CountHoursB = arr[0];
                loadOtherType.CountHoursC = arr[1];
                loadOtherType.Total = arr[0] + arr[1];

                loadList.Add(loadOtherType);
            }

            DataGridTeacherLoadOtherType.ItemsSource = null;
            DataGridTeacherLoadOtherType.ItemsSource = loadList;
        }

        private void ComboBoxTeacher_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = ComboBoxTeacher.SelectedItem as TeacherInfo;
            if(selectedTeacher == null) return;

            _teacherInfos.Add(selectedTeacher);

            ListBoxTeacher.ItemsSource = null;
            ListBoxTeacher.ItemsSource = _teacherInfos;
            ListBoxTeacher.DisplayMemberPath = "Initials";
        }

        private void DataGridOtherType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = DataGridOtherType.SelectedItem as OtherType;
            if(selectedTeacher == null) return;

            _otherTypes.Add(selectedTeacher);
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            _teacherInfos.RemoveAll(i => i.Id >= 0);
            _otherTypes.RemoveAll(i => i.Id >= 0);
            _tempList.RemoveAll(i => i.Id >= 0);
            ListBoxTeacher.ItemsSource = null;
            DataGridTeacherLoadOtherType.ItemsSource = null;
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
        private void ClearLitBox_OnClick(object sender, RoutedEventArgs e)
        {
            ListBoxTeacher.ItemsSource = null;
            _teacherInfos.RemoveAll(i => i.Id >= 0);
        }
    }
}
