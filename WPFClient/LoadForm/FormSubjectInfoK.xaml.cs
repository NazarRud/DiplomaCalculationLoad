using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormSubjectInfoK.xaml
    /// </summary>
    public partial class FormSubjectInfoK : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormSubjectInfoK()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormSubjectInfoK_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridSubjectInfoK.ItemsSource = _uow.Subject.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormSubjectInfoKEdit formSubjectInfoKEdit = new FormSubjectInfoKEdit();
            if (formSubjectInfoKEdit.ShowDialog() == true)
            {
                _uow.SubjectInfoK.InsertOrUpdate(formSubjectInfoKEdit.SubjectInfoK);
                _uow.Save();
            }
            else
            {
                formSubjectInfoKEdit.Close();
            }

            DataGridSubjectInfoK.ItemsSource = _uow.Subject.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridSubjectInfoK.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Subject.Find(selected.Id).SubjectInfoK;
            FormSubjectInfoKEdit formSubjectInfoKEdit = new FormSubjectInfoKEdit(editedItem);
            if (formSubjectInfoKEdit.ShowDialog() == true)
            {
                _uow.SubjectInfoK.InsertOrUpdate(formSubjectInfoKEdit.SubjectInfoK);
                _uow.Save();
            }
            else
            {
                formSubjectInfoKEdit.Close();
            }

            DataGridSubjectInfoK.ItemsSource = _uow.Subject.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridSubjectInfoK.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }

            var subjectInfoK = _uow.Subject.Find(selected.Id).SubjectInfoK;
            _uow.SubjectInfoK.Delete(subjectInfoK.Id);
            _uow.Save();

            DataGridSubjectInfoK.ItemsSource = _uow.Subject.All.ToList();
        }
    }
}
