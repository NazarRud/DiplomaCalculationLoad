using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoadOtherType.xaml
    /// </summary>
    public partial class FormTeacherLoadOtherType : Window
    {
        private IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormTeacherLoadOtherType()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormTeacherLoadOtherType_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var formTeacherLoadOtherTypeEdit = new FormTeacherLoadOtherTypeEdit();
            if (formTeacherLoadOtherTypeEdit.ShowDialog() == true)
            {
                _uow.TeacherLoadOtherType.InsertOrUpdate(formTeacherLoadOtherTypeEdit.TeacherLoadOtherType);
                _uow.Save();
            }
            else
            {
                formTeacherLoadOtherTypeEdit.Close();
            }

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoadOtherType.SelectedItem as TeacherLoadOtherType;
            if (selected == null)
            {
                 MessageBox.Show("Виберіть рядок для редагування !");
                 return;
            }

            var editedItem = _uow.TeacherLoadOtherType.Find(selected.Id);
            var formTeacherLoadOtherTypeEdit = new FormTeacherLoadOtherTypeEdit();
            if (formTeacherLoadOtherTypeEdit.ShowDialog() == true)
            {
                _uow.TeacherLoadOtherType.InsertOrUpdate(formTeacherLoadOtherTypeEdit.TeacherLoadOtherType);
                _uow.Save();
            }
            else
            {
                formTeacherLoadOtherTypeEdit.Close();
            }

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoadOtherType.SelectedItem as TeacherLoadOtherType;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.TeacherLoadOtherType.Delete(selected.Id);
            _uow.Save();

            DataGridTeacherLoadOtherType.ItemsSource = _uow.TeacherLoadOtherType.All.ToList();
        }
    }
}
