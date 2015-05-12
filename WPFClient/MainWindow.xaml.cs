using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void FormK2Report_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormK2Report formK2Report = new FormK2Report();
            formK2Report.ShowDialog();
        }

        private void FormK4Report_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormK4Report formK4Report = new FormK4Report();
            formK4Report.ShowDialog();
        }

        private void FormK5Report_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormK5Report formK5Report = new FormK5Report();
            formK5Report.ShowDialog();
        }
    }
}
