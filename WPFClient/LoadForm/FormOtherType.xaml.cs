using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormOtherType.xaml
    /// </summary>
    public partial class FormOtherType : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormOtherType()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FormOtherType_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridOtherType.ItemsSource = _uow.OtherType.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormOtherTypeEdit formOtherTypeEdit = new FormOtherTypeEdit();
            if (formOtherTypeEdit.ShowDialog() == true)
            {
                _uow.OtherType.InsertOrUpdate(formOtherTypeEdit.OtherType);
                _uow.Save();
            }
            else
            {
                formOtherTypeEdit.Close();
            }

            DataGridOtherType.ItemsSource = _uow.OtherType.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridOtherType.SelectedItem as OtherType;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.OtherType.Find(selected.Id);
            FormOtherTypeEdit formOtherTypeEdit = new FormOtherTypeEdit(editedItem);
            if (formOtherTypeEdit.ShowDialog() == true)
            {
                _uow.OtherType.InsertOrUpdate(formOtherTypeEdit.OtherType);
                _uow.Save();
            }
            else
            {
                formOtherTypeEdit.Close();
            }

            DataGridOtherType.ItemsSource = _uow.OtherType.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridOtherType.SelectedItem as OtherType;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.OtherType.Delete(selected.Id);
            _uow.Save();

            DataGridOtherType.ItemsSource = _uow.OtherType.All.ToList();
        }
    }
}
