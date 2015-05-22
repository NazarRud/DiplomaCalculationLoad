using System.Linq;
using System.Windows;
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
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
