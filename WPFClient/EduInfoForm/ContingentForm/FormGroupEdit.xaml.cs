using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.EduInfoForm.ContingentForm
{
    /// <summary>
    /// Логика взаимодействия для GroupAddEdit.xaml
    /// </summary>
    public partial class FormGroupEdit : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public Group Group { get; set; }

        public FormGroupEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormGroupEdit(Group group)
            : this()
        {
            Group = group;
        }
        private void GroupAddEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxCourse.ItemsSource = Enum.GetValues(typeof (Course)).Cast<Course>();
            ComboBoxEduForm.ItemsSource = Enum.GetValues(typeof(EducationForm)).Cast<EducationForm>();
            ComboBoxEduType.ItemsSource = Enum.GetValues(typeof(EducationType)).Cast<EducationType>();
            ComboBoxOkr.ItemsSource = Enum.GetValues(typeof(QualificationLevel)).Cast<QualificationLevel>();
            ComboBoxCathedra.ItemsSource = _uow.Cathedra.All.ToList();
            ComboBoxCathedra.DisplayMemberPath = "Name";

            if (Group != null)
            {
                TextBoxNameGroup.Text = Group.Name;
                TextBoxCountBudget.Text = Convert.ToString(Group.StudentsCountBudget);
                TextBoxCountContract.Text = Convert.ToString(Group.StudentsCountContract);
                TextBoxCountTotal.Text = Convert.ToString(Group.StudentsCountTotal);
                ComboBoxCourse.Text = Group.Course.ToString();
                ComboBoxCathedra.Text = Group.Cathedra.Name;
                ComboBoxEduForm.Text = Group.EducationForm.ToString();
                ComboBoxEduType.Text = Group.EducationType.ToString();
                ComboBoxOkr.Text = Group.QualificationLevel.ToString();
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Group == null)
                Group = new Group();

            Group.Name = TextBoxNameGroup.Text;
            Group.StudentsCountBudget = Convert.ToInt32(TextBoxCountBudget.Text != String.Empty ? TextBoxCountBudget.Text : "0");
            Group.StudentsCountContract = Convert.ToInt32(TextBoxCountContract.Text != String.Empty ? TextBoxCountContract.Text : "0");
            Group.StudentsCountTotal = Convert.ToInt32(TextBoxCountTotal.Text != String.Empty ? TextBoxCountTotal.Text : "0");
            Group.Course = ComboBoxCourse.SelectedItem is Course ? (Course) ComboBoxCourse.SelectedItem : (Course) 0;
            Group.Cathedra = ComboBoxCathedra.SelectedItem as Cathedra;
            Group.EducationForm = ComboBoxEduForm.SelectedItem is EducationForm ? (EducationForm) ComboBoxEduForm.SelectedItem : (EducationForm) 0;
            Group.EducationType = ComboBoxEduType.SelectedItem is EducationType ? (EducationType) ComboBoxEduType.SelectedItem : (EducationType) 0;
            Group.QualificationLevel =  ComboBoxOkr.SelectedItem is QualificationLevel ? (QualificationLevel) ComboBoxOkr.SelectedItem : (QualificationLevel) 0;

            if (Group.Name == String.Empty || Group.StudentsCountBudget < 0 || Group.StudentsCountContract < 0 || Group.StudentsCountTotal == 0 || Group.Cathedra == null)
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

        private void TextBoxCountBudget_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxCountBudget.Text != String.Empty && TextBoxCountContract.Text != String.Empty)
            {
                TextBoxCountTotal.Text = Convert.ToString(Convert.ToInt32(TextBoxCountBudget.Text) + Convert.ToInt32(TextBoxCountContract.Text));
            }
            else
            {
                TextBoxCountTotal.Text = String.Empty;
            }
        }

        private void TextBoxCountContract_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxCountBudget.Text != String.Empty && TextBoxCountContract.Text != String.Empty)
            {
                TextBoxCountTotal.Text = Convert.ToString(Convert.ToInt32(TextBoxCountBudget.Text) + Convert.ToInt32(TextBoxCountContract.Text));
            }
            else
            {
                TextBoxCountTotal.Text = String.Empty;
            }
        }
    }
}
