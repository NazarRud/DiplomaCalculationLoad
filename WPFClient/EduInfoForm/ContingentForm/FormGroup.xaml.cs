using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm.ContingentForm
{
    /// <summary>
    /// Логика взаимодействия для GroupAdd.xaml
    /// </summary>
    public partial class FormGroup : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public FormGroup()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void GroupAdd_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _uow.Group.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormGroupEdit groupAddEdit = new FormGroupEdit();
            if (groupAddEdit.ShowDialog() == true)
            {
                _uow.Group.InsertOrUpdate(groupAddEdit.Group);
                _uow.Save();
            }
            else
            {
                groupAddEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Group.All.ToList();
        }


        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Group;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Group.Find(selected.Id);

            FormGroupEdit groupAddEdit = new FormGroupEdit(editedItem);
            if (groupAddEdit.ShowDialog() == true)
            {
                _uow.Group.InsertOrUpdate(groupAddEdit.Group);
                _uow.Save();
            }
            else
            {
                groupAddEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Group.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Group;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.Group.Delete(selected.Id);
            _uow.Save();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Group.All.ToList();

        }
    }
}
