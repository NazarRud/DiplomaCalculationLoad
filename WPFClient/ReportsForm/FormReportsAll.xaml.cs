using System;
using System.Collections;
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
using System.Threading.Tasks;
using Reports.Public;
using Data.Entity;
using Data.Repository;

namespace WPFClient.ReportsForm
{
    /// <summary>
    /// Логика взаимодействия для FormReportsAll.xaml
    /// </summary>
    public partial class FormReportsAll : Window
    {
        private ReportsCreator reportsCreator;
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;

        public FormReportsAll()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
            reportsCreator = new ReportsCreator();
            ReportsCreator.CurrentYear = FileRes.CurrentYear;
            InitCombobox();
            TeacherCombobox.ItemsSource = _uow.TeacherInfo.All.Select(teacher => teacher.LastName + " " + teacher.Initials).ToList();
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

            DisciplineCombobox.Items.Add("Лекції");
            DisciplineCombobox.Items.Add("Практичні заняття");
            DisciplineCombobox.Items.Add("Лабораторні заняття");
            DisciplineCombobox.Items.Add("Екзамени");
            DisciplineCombobox.Items.Add("Розрахункові роботи");
            DisciplineCombobox.Items.Add("Модульні роботи");
            DisciplineCombobox.SelectedItem = DisciplineCombobox.Items[0];

        }     

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateK2Button_Click(object sender, RoutedEventArgs e)
        {
            if (K2.IsChecked == true)
            {
                if (TeacherCombobox.SelectedItem != null)
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK2Async(TeacherCombobox.SelectedItem.ToString(), null);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    MessageBox.Show("Виберіть викладача!");
                }
            }
            else if (TotalResults.IsChecked == true)
            {
                ProgressBar.IsIndeterminate = true;
                Task task = reportsCreator.CreatePlanAllTotalAsync(null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (PlanAll.IsChecked == true)
            {
                ProgressBar.IsIndeterminate = true;
                Task task = reportsCreator.CreatePlanAllAsync(null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (PaymentSum.IsChecked == true)
            {
                if (isFullCheckBox.IsChecked == true)
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreatePaymentSumAsync(true, null);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreatePaymentSumAsync(false, null);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

        }

        private void CreateK4Button_Click(object sender, RoutedEventArgs e)
        {
            if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[0])
            {
                ProgressBar.IsIndeterminate = true;
                Task task = reportsCreator.CreateK4Async(EduType.Budget, null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[1])
            {
                ProgressBar.IsIndeterminate = true;
                Task task = reportsCreator.CreateK4Async(EduType.Contract, null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                ProgressBar.IsIndeterminate = true;
                reportsCreator.CreateK4Async(EduType.Budget, null);
                Task task = reportsCreator.CreateK4Async(EduType.Contract, null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            
        }

        private void CreateK5Button_Click(object sender, RoutedEventArgs e)
        {
            if (EduTypeK5Combobox.SelectedItem == EduTypeK5Combobox.Items[0])
            {
                if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[0])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK5Async(TermK5Combobox.Items[0].ToString(), EduType.Budget, null);           // Budget I semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[1])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK5Async(TermK5Combobox.Items[1].ToString(), EduType.Budget, null);           // Budget II semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[2])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK5Async(TermK5Combobox.Items[2].ToString(), EduType.Budget, null);           // Budget All
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    MessageBox.Show("Виберіть семестр!");
                }
            }
            else
            {
                if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[0])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK5Async(TermK5Combobox.Items[0].ToString(), EduType.Contract, null);           // Contract I semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[1])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = reportsCreator.CreateK5Async(TermK5Combobox.Items[1].ToString(), EduType.Contract, null);           // Contract II semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    MessageBox.Show("Виберіть семестр!");
                }                
            }
        }

        private void CreateOtherButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;
            Task task = reportsCreator.CreateLoadDistributionAsync(DisciplineCombobox.SelectedValue.ToString(), _uow.TeacherInfo.All.Select(teacher => teacher.LastName + " " + teacher.Initials).ToList());
            task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CreateDisciplineButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;
            Task task = reportsCreator.CreatePlanAllDisciplineAsync(null);
            task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            
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
