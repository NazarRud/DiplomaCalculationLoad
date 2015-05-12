using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormSubjectInfoEdit.xaml
    /// </summary>
    public partial class FormSubjectInfoB : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormSubjectInfoB()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormSubjectInfoEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridSubjectInfo.ItemsSource = _uow.Subject.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormSubjectInfoEdit formSubjectInfoEdit = new FormSubjectInfoEdit();
            if (formSubjectInfoEdit.ShowDialog() == true)
            {
                _uow.SubjectInfoB.InsertOrUpdate(formSubjectInfoEdit.SubjectInfoB);
                _uow.Save();
            }
            else
            {
                formSubjectInfoEdit.Close();
            }

            DataGridSubjectInfo.ItemsSource = _uow.Subject.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridSubjectInfo.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Subject.Find(selected.Id).SubjectInfoB;
            FormSubjectInfoEdit formSubjectInfoEdit = new FormSubjectInfoEdit(editedItem);
            if (formSubjectInfoEdit.ShowDialog() == true)
            {
                _uow.SubjectInfoB.InsertOrUpdate(formSubjectInfoEdit.SubjectInfoB);
                _uow.Save();
            }
            else
            {
                formSubjectInfoEdit.Close();
            }

            DataGridSubjectInfo.ItemsSource = _uow.Subject.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridSubjectInfo.SelectedItem as Subject;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            var subjectInfoB = _uow.Subject.Find(selected.Id).SubjectInfoB;
            _uow.SubjectInfoB.Delete(subjectInfoB.Id);
            _uow.Save();

            DataGridSubjectInfo.ItemsSource = _uow.Subject.All.ToList();
        }
    }
}
