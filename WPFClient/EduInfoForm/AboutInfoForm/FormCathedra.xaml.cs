using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm.AboutInfoForm
{
    /// <summary>
    /// Логика взаимодействия для Cathedra.xaml
    /// </summary>
    public partial class FormCathedra : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public FormCathedra()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void DataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridCathedra.ItemsSource = _uow.Cathedra.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var cathedraEdit = new FormCathedraEdit();
            if (cathedraEdit.ShowDialog() == true)
            {
                _uow.Cathedra.InsertOrUpdate(cathedraEdit.Cathedra);
                _uow.Save();
            }
            else
            {
                cathedraEdit.Close();
            }
            DataGridCathedra.ItemsSource = null;
            DataGridCathedra.ItemsSource = _uow.Cathedra.All.ToList();

        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridCathedra.SelectedItem as Cathedra;
            
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
          
            var editedItem = _uow.Cathedra.Find(selected.Id);
            FormCathedraEdit cathedraEdit = new FormCathedraEdit(editedItem);

            if (cathedraEdit.ShowDialog() == true)
            {
                _uow.Cathedra.InsertOrUpdate(cathedraEdit.Cathedra);
                _uow.Save();
            }
            else
            {
                cathedraEdit.Close();
            }
            DataGridCathedra.ItemsSource = _uow.Cathedra.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridCathedra.SelectedItem as Cathedra;

            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            _uow.Cathedra.Delete(selected.Id);
            _uow.Save();

            DataGridCathedra.ItemsSource = null;
            DataGridCathedra.ItemsSource = _uow.Cathedra.All.ToList();
        }
    }
}
