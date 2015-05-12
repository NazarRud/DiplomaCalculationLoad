using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для TeachersGeneralInfo.xaml
    /// </summary>
    public partial class FormTeachers : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public FormTeachers()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void TeachersGeneralInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _uow.TeacherInfo.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormTeachersEdit formTeachersEdit = new FormTeachersEdit();
            if (formTeachersEdit.ShowDialog() == true)
            {
                _uow.TeacherInfo.InsertOrUpdate(formTeachersEdit.Teacher);
                _uow.Save();
            }
            else
            {
                formTeachersEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.TeacherInfo.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as TeacherInfo;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.TeacherInfo.Find(selected.Id);
            FormTeachersEdit formTeachersEdit = new FormTeachersEdit(editedItem);
            if (formTeachersEdit.ShowDialog() == true)
            {
                _uow.TeacherInfo.InsertOrUpdate(formTeachersEdit.Teacher);
                _uow.Save();
            }
            else
            {
                formTeachersEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.TeacherInfo.All.ToList();

        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as TeacherInfo;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.TeacherInfo.Delete(selected.Id);
            _uow.Save();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.TeacherInfo.All.ToList();
        }
    }
}
