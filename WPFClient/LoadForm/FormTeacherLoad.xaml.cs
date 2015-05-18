using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeacherLoad.xaml
    /// </summary>
    public partial class FormTeacherLoad : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormTeacherLoad()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormTeacherLoad_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormTeacherLoadEdit formTeacherLoadEdit = new FormTeacherLoadEdit();
            if (formTeacherLoadEdit.ShowDialog() == true)
            {
                _uow.TeacherLoad.InsertOrUpdate(formTeacherLoadEdit.TeacherLoad);
                _uow.Save();
            }
            else
            {
                formTeacherLoadEdit.Close();
            }

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoad.SelectedItem as TeacherLoad;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.TeacherLoad.Find(selected.Id).Subject;

            FormTeacherLoadEdit formTeacherLoadEdit = new FormTeacherLoadEdit(editedItem);
            if (formTeacherLoadEdit.ShowDialog() == true)
            {
                _uow.TeacherLoad.InsertOrUpdate(formTeacherLoadEdit.TeacherLoad);
                _uow.Save();
            }
            else
            {
                formTeacherLoadEdit.Close();
            }

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridTeacherLoad.SelectedItem as TeacherLoad;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }
            _uow.TeacherLoad.Delete(selected.Id);
            _uow.Save();

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void ComboBoxsubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboBoxsubject.SelectedItem as Subject;
            if(selected == null) return;
            var findSubject = _uow.Subject.Find(selected.Id);
            DataGridTeacherLoad.ItemsSource = findSubject.TeacherLoad.ToList();
        }
    }
}
