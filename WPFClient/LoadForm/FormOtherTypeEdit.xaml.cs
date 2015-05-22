using System.Windows;
using Data.Entity;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormOtherTypeEdit.xaml
    /// </summary>
    public partial class FormOtherTypeEdit : Window
    {
        public OtherType OtherType { get; set; }

        public FormOtherTypeEdit()
        {
            InitializeComponent();
        }

        public FormOtherTypeEdit(OtherType otherType) : this()
        {
            OtherType = otherType;
        }

        private void FormOtherTypeEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
