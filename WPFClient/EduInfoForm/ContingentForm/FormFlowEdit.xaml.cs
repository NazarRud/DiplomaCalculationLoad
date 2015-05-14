using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;

namespace WPFClient.EduInfoForm.ContingentForm
{
    /// <summary>
    /// Логика взаимодействия для FlowFormEdit.xaml
    /// </summary>
    public partial class FormFlowEdit : Window
    {
        private readonly IUow _uow;
        readonly App _app = Application.Current as App;
        public Flow Flow { get; set; }
        private readonly List<Group> _listGroups = new List<Group>();
        private readonly List<SubGroup> _listSubGroups = new List<SubGroup>();

        public FormFlowEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormFlowEdit(Flow flow)
            : this()
        {
            Flow = flow;
        }

        private void FlowFormEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridGroup.ItemsSource = _uow.Group.All.ToList();
            ComboBoxEduType.ItemsSource = Enum.GetValues(typeof (EducationType)).Cast<EducationType>();
            ComboBoxEduForm.ItemsSource = Enum.GetValues(typeof (EducationForm)).Cast<EducationForm>();

            if (Flow != null)
            {
                DataGridSubGroup.ItemsSource = Flow.SubGroup.ToList();
                ComboBoxEduType.Text = Flow.EduType.ToString();
                TextBoxNameFlow.Text = Flow.Name;
                TextBoxAllCountBudget.Text = Convert.ToString(Flow.AllCountBudget);
                TextBoxAllCountContract.Text = Convert.ToString(Flow.AllCountContract);
                TextBoxCountSubGroupBudget.Text = Convert.ToString(Flow.CountSubGroupBudget);
                TextBoxCountSubGroupContract.Text = Convert.ToString(Flow.CountSubGroupContract);
                TextBoxTotalStudentFlow.Text = Convert.ToString(Convert.ToInt32(TextBoxAllCountBudget.Text) + Convert.ToInt32(TextBoxAllCountContract.Text));
                ComboBoxEduType.Text = Flow.EduType.ToString();
                ComboBoxEduForm.Text = Flow.EduForm.ToString();
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Flow == null)
                Flow = new Flow();

            Flow.Name = TextBoxNameFlow.Text;
            Flow.AllCountBudget = Convert.ToInt32(TextBoxAllCountBudget.Text != String.Empty ? TextBoxAllCountBudget.Text : "0");
            Flow.AllCountContract = Convert.ToInt32(TextBoxAllCountContract.Text != String.Empty ? TextBoxAllCountContract.Text : "0");
            Flow.CountSubGroupBudget = Convert.ToInt32(TextBoxCountSubGroupBudget.Text != String.Empty ? TextBoxCountSubGroupBudget.Text : "0");
            Flow.CountSubGroupContract = Convert.ToInt32(TextBoxCountSubGroupContract.Text != String.Empty ? TextBoxCountSubGroupContract.Text : "0");
            Flow.Group = ListBoxGroup.ItemsSource as ICollection<Group>;
            Flow.SubGroup = DataGridSubGroup.ItemsSource as ICollection<SubGroup>;
            Flow.EduType = ComboBoxEduType.SelectedItem is EducationType ? (EducationType) ComboBoxEduType.SelectedItem : (EducationType) 0;
            Flow.EduForm = ComboBoxEduForm.SelectedItem is EducationForm? (EducationForm) ComboBoxEduForm.SelectedItem : (EducationForm) 0;

            if (Flow.Name == String.Empty || Flow.AllCountBudget < 0 || Flow.AllCountContract < 0 || Flow.CountSubGroupBudget < 0 || Flow.CountSubGroupContract < 0 || Flow.Group == null)
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

        //Формування потоку на основі груп
        private void DataGridGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = DataGridGroup.SelectedItem as Group;

            if (selected == null) return;

            TextBoxNameFlow.Text += " | " + selected.Name + " | ";
            TextBoxAllCountBudget.Text = Convert.ToString(Convert.ToInt32(TextBoxAllCountBudget.Text != String.Empty ? TextBoxAllCountBudget.Text : "0") + selected.StudentsCountBudget);
            TextBoxAllCountContract.Text = Convert.ToString(Convert.ToInt32(TextBoxAllCountContract.Text != String.Empty ? TextBoxAllCountContract.Text : "0") + selected.StudentsCountContract);
            TextBoxTotalStudentFlow.Text = Convert.ToString(Convert.ToInt32(TextBoxAllCountBudget.Text) + Convert.ToInt32(TextBoxAllCountContract.Text));

            _listGroups.Add(selected);

            ListBoxGroup.ItemsSource = null;
            ListBoxGroup.ItemsSource = _listGroups;
            ListBoxGroup.DisplayMemberPath = "Name";
        }

        //Рохрахунок кількості підгруп
        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxAllCountBudget.Text == String.Empty || TextBoxAllCountContract.Text == String.Empty) return;

            TextBoxTotalStudentFlow.Text = Convert.ToString(Convert.ToInt32(TextBoxAllCountBudget.Text) + Convert.ToInt32(TextBoxAllCountContract.Text));

            int countStudentBudget = Convert.ToInt32(TextBoxAllCountBudget.Text);
            int countStudentContract = Convert.ToInt32(TextBoxAllCountContract.Text);
            int countSubGroupBudget;
            int countSubGroupContract;

            if (countStudentBudget % 15 >= 10)
                countSubGroupBudget = (countStudentBudget / 15) + 1;
            else
            {
                countSubGroupBudget = (countStudentBudget / 15) < 1 ? 1 : (countStudentBudget / 15);
                if (countStudentBudget / countSubGroupBudget >= 19)
                    countSubGroupBudget++;
            }

            if (countStudentContract % 15 >= 10)
                countSubGroupContract = (countStudentContract / 15) + 1;
            else
            {
                countSubGroupContract = (countStudentContract / 15) < 1 ? 1 : (countStudentContract / 15);

                if (countStudentContract / countSubGroupContract >= 19)
                    countSubGroupContract++;
            }


            TextBoxStudBud.Text = Convert.ToString(countStudentBudget / countSubGroupBudget);
            TextBoxStudCon.Text = Convert.ToString(countStudentContract / countSubGroupContract);

            TextBoxCountSubGroupBudget.Text = Convert.ToString(countSubGroupBudget);
            TextBoxCountSubGroupContract.Text = Convert.ToString(countSubGroupContract);
        }

        //Очещення полів
        private void CancleSelectedButton_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxNameFlow.Text = String.Empty;
            TextBoxAllCountBudget.Text = String.Empty;
            TextBoxAllCountContract.Text = String.Empty;
            TextBoxTotalStudentFlow.Text = String.Empty;
            TextBoxCountSubGroupBudget.Text = String.Empty;
            TextBoxCountSubGroupContract.Text = String.Empty;
            TextBoxStudBud.Text = String.Empty;
            TextBoxStudCon.Text = String.Empty;
            ListBoxGroup.ItemsSource = null;
            _listGroups.RemoveAll(g => g.Id >= 0);
            _listSubGroups.RemoveAll(sg => sg.Name != String.Empty);
        }

        //Поділ на підгрупи
        private void ListBoxGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ListBoxGroup.SelectedItem as Group;
            if (selected == null) return;

            if (CheckBoxSubGroup.IsChecked == true)
            {
                for (int i = 1; i < 3; i++)
                {
                    SubGroup objTemp = new SubGroup
                    {
                        Name = selected.Name + "_" + i + "Б",
                        CountStudent = Convert.ToInt32(TextBoxStudBud.Text)
                    };
                    _listSubGroups.Add(objTemp);
                }
            }
            else
            {

                SubGroup objTemp = new SubGroup
                {
                    Name = selected.Name,
                    CountStudent = Convert.ToInt32(TextBoxStudBud.Text)
                };
                _listSubGroups.Add(objTemp);
            }

            DataGridSubGroup.ItemsSource = null;
            DataGridSubGroup.ItemsSource = _listSubGroups;

        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = DataGridSubGroup.SelectedItem as SubGroup;
            if (selected == null)
            {
                MessageBox.Show("Виберіть рядок для видалення !");
                return;
            }
            
            _uow.SubGroup.Delete(selected.Id);
            _uow.Save();

            DataGridSubGroup.ItemsSource = Flow.SubGroup.ToList();
        }

        private void DataGridSubGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int totalStud = Convert.ToInt32(TextBoxTotalStudentFlow.Text);

            int oresidue = 0;
            foreach (var item in DataGridSubGroup.ItemsSource.Cast<SubGroup>())
            {
                oresidue += item.CountStudent;
            }
            totalStud -= oresidue;
            TextBoxOresidue.Text = Convert.ToString(totalStud);
        }
    }
}
