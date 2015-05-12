using System;
using System.Windows;
using Data.Entity;

namespace WPFClient.EduInfoForm.AboutInfoForm
{
    /// <summary>
    /// Логика взаимодействия для FacultyEdit.xaml
    /// </summary>
    public partial class FormFacultyEdit : Window
    {
        public Faculty Faculty { get; set; }
        public FormFacultyEdit()
        {
            InitializeComponent();
        }

        public FormFacultyEdit(Faculty faculty)
            : this()
        {
            Faculty = faculty;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Faculty == null)
                Faculty = new Faculty();


            Faculty.Name = TextBoxName.Text;
            Faculty.FullName = TextBoxFullName.Text;

            if (Faculty.Name == String.Empty || Faculty.FullName == String.Empty)
            {
                MessageBox.Show("Одне або декілька полів не заповненні !");
                return;
            }
            DialogResult = true;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void FacultyEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Faculty != null)
            {
                TextBoxName.Text = Faculty.Name;
                TextBoxFullName.Text = Faculty.FullName;
            }
        }
    }
}
