using System;
using System.Collections.Generic;
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
            var selectedFlow = DataGridFlow.SelectedItem as Flow;

            if (selectedFlow == null)
                return;

            int T = Convert.ToInt32(TextBoxCountWeek.Text);
            int G = Convert.ToInt32(TextBoxCountBudgetGroup);
            int DG = Convert.ToInt32(TextBoxCountSubject.Text);
            int d = Convert.ToInt32(TextBoxCountDek.Text);

            int countStudB = selectedFlow.AllCountBudget;
            int countStudC = selectedFlow.AllCountContract;

            double totalBudget = 0;
            double totalContract = 0;

            switch (selectedTypeWork)
            {
                case TypeWork.Індивідуальні_заняття:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.зі_студентами:
                                {
                                    //
                                } break;

                            case SubTypeWork.з_магістрами:
                                {
                                    totalBudget = 10 * countStudB;
                                    totalContract = 10 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }

                    }
                    break;

                case TypeWork.Керівництво_практикою:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.навчальною:
                                {
                                    totalBudget = 30 * T * G;
                                    totalContract = 30 * T * G;
                                } break;
                            case SubTypeWork.виробничою:
                                {
                                    totalBudget = 10 * T * G / 2;
                                    totalContract = 10 * T * G / 2;
                                } break;
                            case SubTypeWork.проект_технол:
                                {
                                    totalBudget = 10 * T * G;
                                    totalContract = 10 * T * G;
                                } break;
                            case SubTypeWork.переддиплом:
                                {
                                    totalBudget = 1 * T * countStudB;
                                    totalContract = 1 * T * countStudC;
                                } break;
                            case SubTypeWork.науков_дослід:
                                {
                                    totalBudget = 1 * T * countStudB;
                                    totalContract = 1 * T * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Керівництво_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 16.5 * countStudB;
                                    totalContract = 16.5 * countStudC;
                                } break;

                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 17 * countStudB;
                                    totalContract = 17 * countStudC;
                                } break;

                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 28 * countStudB;
                                    totalContract = 28 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }

                    } break;

                case TypeWork.Консультування_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 3 * countStudB;
                                    totalContract = 3 * countStudC;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Рецензування_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 2 * countStudB;
                                    totalContract = 2 * countStudC;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 3 * countStudB;
                                    totalContract = 3 * countStudC;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Консультування_перед_держ_екзам:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 2 * G * DG;
                                    totalContract = 2 * G * DG;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 2 * G * DG;
                                    totalContract = 2 * G * DG;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Роб_в_ДЕК_захист_дипл:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам_усн:
                    {
                        if (selectedSubTypeWork == SubTypeWork.бакалаврів)
                        {
                            totalBudget = 0.5 * d * countStudB;
                            totalContract = 0.5 * d * countStudB;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам_пис:
                    {
                        if (selectedSubTypeWork == SubTypeWork.бакалаврів)
                        {
                            totalBudget = 4 * d * G + 0.5 * countStudB;
                            totalContract = 4 * d * G + 0.5 * countStudB;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам:
                    {
                        if (selectedSubTypeWork == SubTypeWork.спеціалістів)
                        {
                            //
                        }
                    } break;

                case TypeWork.Керівництво:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.аспірантами:
                                {
                                    totalBudget = 25 * countStudB;
                                    totalContract = 25 * countStudC;
                                } break;
                            case SubTypeWork.здобув_стаж:
                                {
                                    totalBudget = 12.5 * countStudB;
                                    totalContract = 12.5 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Заняття_з_аспірантами:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.лекції:
                                {
                                    //
                                } break;
                            case SubTypeWork.семінари_практич_зан:
                                {
                                    //
                                } break;
                            case SubTypeWork.консульт_реценз_екз:
                                {
                                    //
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Консультування_докторантів:
                    {
                        //totalBudget = 25*;
                        //totalContract = 25*;
                    } break;

                default:
                    {
                        MessageBox.Show("Виберіть значення в полі вид роботи !");

                    } break;
            }

            TextBoxTotalBudget.Text = totalBudget.ToString();
            TextBoxTotalContract.Text = totalContract.ToString();

        }
    }
}
