using System;
using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.EduInfoForm
{
    /// <summary>
    /// Логика взаимодействия для FormSubjectEdit.xaml
    /// </summary>
    public partial class FormSubjectEdit : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public Subject Subject { get; set; }
        public FormSubjectEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormSubjectEdit(Subject subject)
            : this()
        {
            Subject = subject;
        }

        private void FormSubjectEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSemestr.ItemsSource = Enum.GetValues(typeof (Semestr)).Cast<Semestr>();
            if (Subject == null) return;

            TextBoxName.Text = Subject.Name;
            TextBoxShortName.Text = Subject.ShortName;
            ComboBoxSemestr.Text = Subject.Semestr.ToString();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Subject == null)
                Subject = new Subject();

            Subject.Name = TextBoxName.Text;
            Subject.ShortName = TextBoxShortName.Text;
            Subject.Semestr = (Semestr)ComboBoxSemestr.SelectedItem;
           
            if (Subject.Name == String.Empty || Subject.ShortName == String.Empty)
            {
                MessageBox.Show("Одне або декілька полів не заповненні !");
                return;
            }

            DialogResult = true;
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
