using System.Linq;
using System.Windows;
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

            DataGridTeacherLoad.ItemsSource = _uow.TeacherLoad.All.ToList();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
