using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Entity;
using Data.Entity.Enum;
using Data.Repository;
using WPFClient.CalculateTypeWork;

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
        private Flow _selected;
        public FormOtherTypeEdit()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
        }

        public FormOtherTypeEdit(OtherType otherType)
            : this()
        {
            OtherType = otherType;
        }

        private void FormOtherTypeEdit_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (OtherType != null)
            {
                TypeWorkComboBox.Text = OtherType.TypeWork.ToString();
                SubTypeWorkComboBox.Text = OtherType.SubTypeWork.ToString();
                SemestrComboBox.Text = OtherType.Semestr.ToString();
                DataGridFlow.ItemsSource = new List<Flow> { OtherType.Flow };
                TextBoxTotalBudget.Text = OtherType.TotalBudget.ToString();
                TextBoxTotalContract.Text = OtherType.TotalContract.ToString();
            }

            TypeWorkComboBox.ItemsSource = Enum.GetValues(typeof(TypeWork)).Cast<TypeWork>();
            SubTypeWorkComboBox.ItemsSource = Enum.GetValues(typeof(SubTypeWork)).Cast<SubTypeWork>();
            SemestrComboBox.ItemsSource = Enum.GetValues(typeof(Semestr)).Cast<Semestr>();
            DataGridFlow.ItemsSource = _uow.Flow.All.ToList();

        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (OtherType == null)
                OtherType = new OtherType();

            OtherType.TypeWork = TypeWorkComboBox.SelectedItem is TypeWork ? (TypeWork)TypeWorkComboBox.SelectedItem : (TypeWork)0;
            OtherType.SubTypeWork = SubTypeWorkComboBox.SelectedItem is SubTypeWork ? (SubTypeWork)SubTypeWorkComboBox.SelectedItem : (SubTypeWork)0;
            OtherType.Semestr = SemestrComboBox.SelectedItem is Semestr ? (Semestr)SemestrComboBox.SelectedItem : (Semestr)0;
            OtherType.TotalBudget = Convert.ToDouble(TextBoxTotalBudget.Text);
            OtherType.TotalContract = Convert.ToDouble(TextBoxTotalContract.Text);
            OtherType.TotalHourse = Convert.ToDouble(TextBoxTotalHourse.Text);
            OtherType.Flow = DataGridFlow.SelectedItem as Flow;

            DialogResult = true;

        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CalculationButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedTypeWork = TypeWorkComboBox.SelectedItem is TypeWork ? (TypeWork)TypeWorkComboBox.SelectedValue : (TypeWork)0;
            var selectedSubTypeWork = SubTypeWorkComboBox.SelectedItem is SubTypeWork ? (SubTypeWork)SubTypeWorkComboBox.SelectedValue : (SubTypeWork)0;

            int T = Convert.ToInt32(TextBoxCountWeek.Text);
            int G = Convert.ToInt32(TextBoxCountBudgetGroup.Text);
            int GK = Convert.ToInt32(TextBoxCountContractGroup.Text);
            int DG = Convert.ToInt32(TextBoxCountSubject.Text);
            int d = Convert.ToInt32(TextBoxCountDek.Text);
            int N = Convert.ToInt32(TextBoxScopeSubject.Text);
            int countAspDok = Convert.ToInt32(TextBoxCountHoursAspDok.Text);
            int countHoursExam = Convert.ToInt32(TextBoxCountHoursExam.Text);

            int countStudB = _selected.AllCountBudget;
            int countStudC = _selected.AllCountContract;

            var itemList = CalculateOtherType.Calculate(selectedTypeWork, selectedSubTypeWork, countStudB, countStudC, countHoursExam, countAspDok, T, N, G, GK, DG, d);

            TextBoxTotalBudget.Text = itemList[0].ToString();
            TextBoxTotalContract.Text = itemList[1].ToString();
            TextBoxTotalHourse.Text = (itemList[0] + itemList[1]).ToString();

        }

        private void DataGridFlow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selected = DataGridFlow.SelectedItem as Flow;

            if (_selected == null)
                return;

            TextBoxCountBudgetGroup.Text = _selected.Group.Count(g => g.EducationType == EducationType.Бюджет).ToString();
            TextBoxCountContractGroup.Text = _selected.Group.Count(g => g.EducationType == EducationType.Контракт).ToString();


        }
    }
}
