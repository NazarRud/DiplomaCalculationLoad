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

        }
    }
}
