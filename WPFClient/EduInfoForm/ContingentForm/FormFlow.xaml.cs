using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm.ContingentForm
{
    /// <summary>
    /// Логика взаимодействия для FlowForm.xaml
    /// </summary>
    public partial class FormFlow : Window
    {
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        public FormFlow()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        private void FlowForm_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _uow.Flow.All.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormFlowEdit flowFormEdit = new FormFlowEdit();
            if (flowFormEdit.ShowDialog() == true)
            {
                _uow.Flow.InsertOrUpdate(flowFormEdit.Flow);
                _uow.Save();
            }
            else
            {
                flowFormEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Flow.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Flow;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для редагування !");
                return;
            }
            var editedItem = _uow.Flow.Find(selected.Id);

            FormFlowEdit flowFormEdit = new FormFlowEdit(editedItem);
            if (flowFormEdit.ShowDialog() == true)
            {
                _uow.Flow.InsertOrUpdate(flowFormEdit.Flow);
                _uow.Save();
            }
            else
            {
                flowFormEdit.Close();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Flow.All.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Flow;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }

            var list = _uow.SubGroup.All.Where(s => s.Flow.Id == selected.Id);
            foreach (var subGroup in list)
            {
                _uow.SubGroup.Delete(subGroup.Id);
            }
            _uow.Save();

            _uow.Flow.Delete(selected.Id);
            _uow.Save();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _uow.Flow.All.ToList();
        }
    }
}
