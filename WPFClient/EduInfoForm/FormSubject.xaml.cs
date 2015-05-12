using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для FormSubject.xaml
    /// </summary>
    public partial class FormSubject : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public FormSubject()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormSubject_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _uow.Subject.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormSubjectEdit formSubjectEdit = new FormSubjectEdit();
            if (formSubjectEdit.ShowDialog() == true)
            {
                _uow.Subject.InsertOrUpdate(formSubjectEdit.Subject);
                _uow.Save();
            }
            else
            {
                formSubjectEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Subject.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Subject.Find(selected.Id);

            FormSubjectEdit formSubjectEdit = new FormSubjectEdit(editedItem);
            if (formSubjectEdit.ShowDialog() == true)
            {
                _uow.Subject.InsertOrUpdate(formSubjectEdit.Subject);
                _uow.Save();
            }
            else
            {
                formSubjectEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Subject.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.Subject.Delete(selected.Id);
            _uow.Save();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Subject.All.ToList();
        }
    }
}
