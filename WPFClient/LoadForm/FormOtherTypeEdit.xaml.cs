using System;
using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.LoadForm
{
    /// <summary>
    /// Логика взаимодействия для FormOtherTypeEdit.xaml
    /// </summary>
    public partial class FormOtherTypeEdit : Window
    {
        private IUow _uow;
        public OtherType OtherType { get; set; }
        private readonly App _app = Application.Current as App;
        public FormOtherTypeEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormOtherTypeEdit(OtherType otherType) : this()
        {
            OtherType = otherType;
        }

        private void FormOtherTypeEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            TypeWorkComboBox.ItemsSource = Enum.GetValues(typeof (TypeWork)).Cast<TypeWork>();
            SubTypeWorkComboBox.ItemsSource = Enum.GetValues(typeof (SubTypeWork)).Cast<SubTypeWork>();
            SemestrComboBox.ItemsSource = Enum.GetValues(typeof (Semestr)).Cast<Semestr>();
            DataGridFlow.ItemsSource = _uow.Flow.All.ToList();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CalculationButton_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
