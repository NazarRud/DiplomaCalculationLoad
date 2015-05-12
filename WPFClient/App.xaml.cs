using System.Windows;
using Data.Repository;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IUow Uow { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Uow = new Uow();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Uow.Dispose();
            base.OnExit(e);
        }
    }
}
