using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Text.RegularExpressions;
using Reports.Public;

namespace WPFClient.ReportsForm
{
    /// <summary>
    /// Логика взаимодействия для FormReportsAll.xaml
    /// </summary>
    public partial class FormReportsAll : Window
    {
        private ReportsCreator reportsCreator;
        List<string> teachList = new List<string>();

        public FormReportsAll()
        {
            InitializeComponent();
            reportsCreator = new ReportsCreator();
            InitCombo();
            InitCombobox();
            //this.TeacherCombobox.SelectionChanged += new SelectionChangedEventHandler(TeacherCombobox_SelectionChanged);
        }

        private void InitCombobox()
        {
            EduTypeK4Combobox.Items.Add("Бюджет");
            EduTypeK4Combobox.Items.Add("Контракт");
            EduTypeK4Combobox.Items.Add("Всі");
            EduTypeK4Combobox.SelectedItem = EduTypeK4Combobox.Items[2];

            EduTypeK5Combobox.Items.Add("Бюджет");
            EduTypeK5Combobox.Items.Add("Контракт");
            EduTypeK5Combobox.SelectedItem = EduTypeK5Combobox.Items[0];

            TermOtherCombobox.Items.Add("I семестр");
            TermOtherCombobox.Items.Add("II семестр");
            TermOtherCombobox.Items.Add("Всі");
            TermOtherCombobox.SelectedItem = TermOtherCombobox.Items[0];

            DisciplineCombobox.Items.Add("Лекції");
            DisciplineCombobox.Items.Add("Практичні заняття");
            DisciplineCombobox.Items.Add("Лабораторні заняття");
            DisciplineCombobox.Items.Add("Екзамени");
            DisciplineCombobox.Items.Add("Розрахункові роботи");
            DisciplineCombobox.Items.Add("Модульні роботи");
            DisciplineCombobox.SelectedItem = DisciplineCombobox.Items[0];

        }     

        private void InitCombo()
        {
            teachList.Add("Рудь");
            teachList.Add("Храпов");
            teachList.Add("Чхаїдзе");
            teachList.Add("Павлов");
            teachList.Add("Сперкач");
            teachList.Add("Капітоненко");
            teachList.Add("Лещенко");
            teachList.Add("Ромашкін");
            teachList.Add("Рокосовський");
            teachList.Add("Самойлов");
            teachList.Add("Дзюба");
            teachList.Add("Плющенко");
            teachList.Add("Морозова");
            teachList.Add("Дереновський");
            teachList.Add("Деркач");
            teachList.Add("Чмутов");
            teachList.Add("Литвиновський");
            TeacherCombobox.ItemsSource = teachList;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateK2Button_Click(object sender, RoutedEventArgs e)
        {
            if (K2.IsChecked == true)
            {
                reportsCreator.CreateK2Async();
            }
            else if (TotalResults.IsChecked == true)
            {
                reportsCreator.CreatePlanAllTotalAsync();
            }
            else if (PlanAll.IsChecked == true)
            {
                reportsCreator.CreatePlanAllAsync();
            }
            else if (PaymentSum.IsChecked == true)
            {
                reportsCreator.CreatePaymentSumAsync();
            }
           
        }

        private void CreateK4Button_Click(object sender, RoutedEventArgs e)
        {
            if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[0])
            {
                reportsCreator.CreateK4Async(EduType.Budget);
            }
            else if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[1])
            {
                reportsCreator.CreateK4Async(EduType.Contract);
            }
            else
            {
                reportsCreator.CreateK4Async(EduType.Budget);
                reportsCreator.CreateK4Async(EduType.Contract);
            }
            
        }

        private void CreateK5Button_Click(object sender, RoutedEventArgs e)
        {
            if (EduTypeK5Combobox.SelectedItem == EduTypeK5Combobox.Items[0])
            {
                reportsCreator.CreateK5Async(EduType.Budget);
            }
            else if (EduTypeK5Combobox.SelectedItem == EduTypeK5Combobox.Items[1])
            {
                reportsCreator.CreateK5Async(EduType.Contract);
            }
            else
            {
                reportsCreator.CreateK5Async(EduType.Budget);
                reportsCreator.CreateK5Async(EduType.Contract);
            }
        }

        private void CreateOtherButton_Click(object sender, RoutedEventArgs e)
        {
            reportsCreator.CreateLoadDistributionAsync(DisciplineCombobox.SelectedValue.ToString());
        }

        private void CreateDisciplineButton_Click(object sender, RoutedEventArgs e)
        {
            reportsCreator.CreatePlanAllDisciplineAsync();
        }

        private void EduTypeK5Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EduTypeK5Combobox.SelectedItem == EduTypeK5Combobox.Items[0])
            {
                TermK5Combobox.Items.Clear();
                TermK5Combobox.Items.Add("I семестр");
                TermK5Combobox.Items.Add("II семестр");
                TermK5Combobox.Items.Add("Всі");
                TermK5Combobox.SelectedItem = EduTypeK5Combobox.Items[0];
            }
            else if (EduTypeK5Combobox.SelectedItem == EduTypeK5Combobox.Items[1])
            {
                TermK5Combobox.Items.Clear();
                TermK5Combobox.Items.Add("I семестр");
                TermK5Combobox.Items.Add("II семестр");
                TermK5Combobox.SelectedItem = EduTypeK5Combobox.Items[0];
            }
        }   

    }
}
