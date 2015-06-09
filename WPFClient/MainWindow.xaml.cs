using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;
using WPFClient.EduInfoForm;
using WPFClient.EduInfoForm.AboutInfoForm;
using WPFClient.EduInfoForm.ContingentForm;
using WPFClient.LoadForm;
using WPFClient.ReportsForm;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public MainWindow()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridTeacherTotalLoad.ItemsSource = _uow.TeacherInfo.All.ToList();
        }

        private void FormFaculty_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormFaculty formFaculty = new FormFaculty();
            formFaculty.ShowDialog();
        }

        private void FormCathedra_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormCathedra formCathedra = new FormCathedra();
            formCathedra.ShowDialog();
        }

        private void FormGroup_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormGroup formGroup = new FormGroup();
            formGroup.ShowDialog();
        }

        private void FormFlow_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormFlow formFlow = new FormFlow();
            formFlow.ShowDialog();
        }

        private void FormSubject_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormSubject formSubject = new FormSubject();
            formSubject.ShowDialog();
        }

        private void FormTeachersInfo_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormTeachers formTeachers = new FormTeachers();
            formTeachers.ShowDialog();
        }

        private void FormSubjectInfoB_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormSubjectInfoB formSubjectInfoB = new FormSubjectInfoB();
            formSubjectInfoB.ShowDialog();
        }

        private void FormSubjectInfoK_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormSubjectInfoK formSubjectInfoK = new FormSubjectInfoK();
            formSubjectInfoK.ShowDialog();
        }

        private void FormTeacherLoad_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormTeacherLoad formTeacherLoad = new FormTeacherLoad();
            formTeacherLoad.ShowDialog();
        }

        private void Reports_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var reportsAll = new FormReportsAll();
            reportsAll.ShowDialog();
        }


        private void FormOtherTypeMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            FormOtherType formOtherType = new FormOtherType();
            formOtherType.ShowDialog();
        }

        private void FormTeacherLoadOtherType_MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            FormTeacherLoadOtherType formTeacherLoadOtherType = new FormTeacherLoadOtherType();
            formTeacherLoadOtherType.ShowDialog();
        }
        private void FormTeachersSalary_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormTeachersSalary formTeachersSalary = new FormTeachersSalary();
            formTeachersSalary.ShowDialog();
        }

        private void FormTeachersAllowance_MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridTeacherTotalLoad_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = DataGridTeacherTotalLoad.SelectedItem as TeacherInfo;
            if(selected == null) return;

            DataGridLoadSubject.ItemsSource = selected.TeacherLoad.ToList();
            DataGridLoadOtherType.ItemsSource = selected.TeacherLoadOtherType.ToList();

            double tempHoursLoad = selected.TeacherLoad.Sum(load => load.TotalHourse);
            double tempHoursOtherLoad = selected.TeacherLoadOtherType.Sum(load => load.Total);

            double tempCountBudgetLoad = selected.TeacherLoad.Sum(load => load.TotalHoursB);
            double tempCountBudgetOtherLoad = selected.TeacherLoadOtherType.Sum(load => load.CountHoursB);

            double tempCountContractLoad = selected.TeacherLoad.Sum(load => load.TotalHoursK);
            double tempCountContractOtherLoad = selected.TeacherLoadOtherType.Sum(load => load.CountHoursC);

            TextBoxTotalHours.Text = Convert.ToString(tempHoursLoad + tempHoursOtherLoad);
            TextBoxTotalB.Text = Convert.ToString(tempCountBudgetLoad + tempCountBudgetOtherLoad);
            TextBoxTotalK.Text = Convert.ToString(tempCountContractLoad + tempCountContractOtherLoad);

            DataGridTeacherTotalLoad.ItemsSource = _uow.TeacherInfo.All.ToList();
        }

        private void RefrehButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataGridTeacherTotalLoad.ItemsSource = _uow.TeacherInfo.All.ToList();
        }
    }
}
