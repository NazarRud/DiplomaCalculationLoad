using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для TeachersGeneralInfoEdit.xaml
    /// </summary>
    public partial class FormTeachersEdit : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public TeacherInfo Teacher { get; set; }

        public FormTeachersEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormTeachersEdit(TeacherInfo teacherInfo)
            : this()
        {
            Teacher = teacherInfo;
        }

        private void TeachersGeneralInfoEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxAppointment.ItemsSource = Enum.GetValues(typeof (Appointment)).Cast<Appointment>();
            ComboBoxDegree.ItemsSource = Enum.GetValues(typeof(Degree)).Cast<Degree>();
            ComboBoxRank.ItemsSource = Enum.GetValues(typeof(Rank)).Cast<Rank>();
            ComboBoxCathedra.ItemsSource = _uow.Cathedra.All.ToList();
            ComboBoxCathedra.DisplayMemberPath = "Name";

            if (Teacher != null)
            {
                TextBoxLastName.Text = Teacher.LastName;
                TextBoxName.Text = Teacher.Name;
                TextBoxMiddleName.Text = Teacher.MiddleName;
                TextBoxInitials.Text = Teacher.Initials;
                ComboBoxAppointment.Text = Teacher.Appointment.ToString();
                ComboBoxDegree.Text = Teacher.Degree.ToString();
                ComboBoxRank.Text = Teacher.Rank.ToString();
                ComboBoxCathedra.Text = Teacher.Cathedra.Name;
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Teacher == null)
                Teacher = new TeacherInfo();

            Teacher.LastName = TextBoxLastName.Text;
            Teacher.Name = TextBoxName.Text;
            Teacher.MiddleName = TextBoxMiddleName.Text;
            Teacher.Initials = TextBoxInitials.Text;
            Teacher.Appointment = ComboBoxAppointment.SelectedItem is Appointment ? (Appointment) ComboBoxAppointment.SelectedItem : (Appointment) 0;
            Teacher.Degree = ComboBoxDegree.SelectedItem is Degree ? (Degree) ComboBoxDegree.SelectedItem : (Degree) 0;
            Teacher.Rank = ComboBoxRank.SelectedItem is Rank ? (Rank) ComboBoxRank.SelectedItem : (Rank) 0;
            Teacher.Cathedra = ComboBoxCathedra.SelectedItem as Cathedra;

            if (Teacher.LastName == String.Empty || Teacher.Name == String.Empty || Teacher.MiddleName == String.Empty || Teacher.Initials == String.Empty || Teacher.Cathedra == null)
            {
                MessageBox.Show("Одне або декілька полів не заповнені !");
                return;
            }

            DialogResult = true;
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ComboBoxCathedra_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCathedra = ComboBoxCathedra.SelectedItem as Cathedra;
            if (selectedCathedra != null)
            {
                TextBoxFaculty.Text = selectedCathedra.Faculty.Name;
            }
        }

        private void TextBoxLastName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxLastName.Text != String.Empty && TextBoxName.Text != String.Empty && TextBoxMiddleName.Text != String.Empty)
            {
                
            }
        }

        private void TextBoxName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBoxMiddleName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
