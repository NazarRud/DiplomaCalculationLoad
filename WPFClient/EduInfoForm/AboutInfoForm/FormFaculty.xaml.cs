using System.Linq;
using System.Windows;
using Data.Repository;
using Data.Entity;

namespace WPFClient.EduInfoForm.AboutInfoForm
{
    /// <summary>
    /// Логика взаимодействия для Faculty.xaml
    /// </summary>
    public partial class FormFaculty : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public FormFaculty()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void Faculty_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridFaculty.ItemsSource = _uow.Faculty.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormFacultyEdit facultyEdit = new FormFacultyEdit();
            if (facultyEdit.ShowDialog() == true)
            {
                _uow.Faculty.InsertOrUpdate(facultyEdit.Faculty);
                _uow.Save();
            }
            else
            {
                facultyEdit.Close();
            }
            DataGridFaculty.ItemsSource = null;
            DataGridFaculty.ItemsSource = _uow.Faculty.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridFaculty.SelectedItem as Faculty;

            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }

            var editedItem = _uow.Faculty.Find(selected.Id);
            FormFacultyEdit facultyEdit = new FormFacultyEdit(editedItem);

            if (facultyEdit.ShowDialog() == true)
            {
                _uow.Faculty.InsertOrUpdate(facultyEdit.Faculty);
                _uow.Save();
            }
            else
            {
                facultyEdit.Close();
            }
            DataGridFaculty.ItemsSource = null;
            DataGridFaculty.ItemsSource = _uow.Faculty.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridFaculty.SelectedItem as Faculty;

            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.Faculty.Delete(selected.Id);
            _uow.Save();

            DataGridFaculty.ItemsSource = null;
            DataGridFaculty.ItemsSource = _uow.Faculty.All.ToList();
        }
    }
}
