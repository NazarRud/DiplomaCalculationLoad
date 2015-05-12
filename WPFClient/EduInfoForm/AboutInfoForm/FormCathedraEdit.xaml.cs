using System;
using System.Linq;
using System.Windows;
using Data.Entity;
using Data.Repository;

namespace WPFClient.EduInfoForm.AboutInfoForm
{
    /// <summary>
    /// Логика взаимодействия для CathedraEdit.xaml
    /// </summary>
    public partial class FormCathedraEdit : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public Cathedra Cathedra { get; set; }
        public FormCathedraEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormCathedraEdit(Cathedra cathedra) : this()
        {
            Cathedra = cathedra;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Cathedra == null)
                Cathedra = new Cathedra();

            Cathedra.Name = TextBoxName.Text;
            Cathedra.FullName = TextBoxFullName.Text;
            Cathedra.Faculty = ComboBox.SelectedItem as Faculty;

            if (Cathedra.Name == String.Empty || Cathedra.FullName == String.Empty || Cathedra.Faculty == null)
            {
                MessageBox.Show("Одне або декілька полів не заповнені !");
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CathedraEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox.ItemsSource = _uow.Faculty.All.ToList();
            ComboBox.DisplayMemberPath = "Name";

            if (Cathedra != null)
            {
                TextBoxName.Text = Cathedra.Name;
                TextBoxFullName.Text = Cathedra.FullName;
                ComboBox.Text = Cathedra.Faculty.Name;
            }
        }
    }
}
