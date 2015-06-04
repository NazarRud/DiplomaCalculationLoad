using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для FormTeachersSalary.xaml
    /// </summary>
    public partial class FormTeachersSalary : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormTeachersSalary()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormTeachersSalary_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridPayment.ItemsSource = _uow.Payment.All.ToList();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormTeachersSalaryEdit formTeachersSalaryEdit = new FormTeachersSalaryEdit();
            if (formTeachersSalaryEdit.ShowDialog() == true)
            {
                _uow.Payment.InsertOrUpdate(formTeachersSalaryEdit.Payment);
                _uow.Save();
            }
            else
            {
                formTeachersSalaryEdit.Close();
            }

            DataGridPayment.ItemsSource = _uow.Payment.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridPayment.SelectedItem as Payment;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Payment.Find(selected.Id);

            FormTeachersSalaryEdit formTeachersSalaryEdit = new FormTeachersSalaryEdit(editedItem);
            if (formTeachersSalaryEdit.ShowDialog() == true)
            {
                _uow.Payment.InsertOrUpdate(formTeachersSalaryEdit.Payment);
                _uow.Save();
            }
            else
            {
                formTeachersSalaryEdit.Close();
            }

            DataGridPayment.ItemsSource = _uow.Payment.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridPayment.SelectedItem as Payment;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.Payment.Delete(selected.Id);
            _uow.Save();

            DataGridPayment.ItemsSource = _uow.TeacherInfo.All.ToList();
        }
    }
}
