using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using Data.Entity;
using Data.Entity.Enum;
using Reports.Public;
using Data.Repository;
using WPFClient.Model;

namespace WPFClient.ReportsForm
{
    /// <summary>
    /// Логика взаимодействия для FormReportsAll.xaml
    /// </summary>
    public partial class FormReportsAll : Window
    {
        private readonly ReportsCreator _reportsCreator;
        private readonly IUow _uow;
        private readonly App _app = Application.Current as App;
        private ArrayList _listOfTables;

        public FormReportsAll()
        {
            if (_app != null) _uow = _app.Uow;
            InitializeComponent();
            _reportsCreator = new ReportsCreator();
            ReportsCreator.CurrentYear = FileRes.CurrentYear;
            InitCombobox();

            ComboBoxTeacherInfo.ItemsSource = _uow.TeacherInfo.All.ToList();
            ComboBoxTeacherInfo.DisplayMemberPath = "Initials";
        }

        //private void AddTables()
        //{
        //    _listOfTables = new ArrayList();
        //    _listOfTables.Add(_uow.Flow.All.ToList());                   //0
        //    _listOfTables.Add(_uow.Faculty.All.ToList());                //1
        //    _listOfTables.Add(_uow.Cathedra.All.ToList());               //2
        //    _listOfTables.Add(_uow.Group.All.ToList());                  //3
        //    _listOfTables.Add(_uow.SubGroup.All.ToList());               //4
        //    _listOfTables.Add(_uow.Subject.All.ToList());                //5
        //    _listOfTables.Add(_uow.SubjectInfoB.All.ToList());           //6
        //    _listOfTables.Add(_uow.SubjectInfoK.All.ToList());           //7
        //    _listOfTables.Add(_uow.TeacherInfo.All.ToList());            //8
        //    _listOfTables.Add(_uow.TeacherLoad.All.ToList());            //9
        //    _listOfTables.Add(_uow.TeacherLoadOtherType.All.ToList());   //10
        //    _listOfTables.Add(_uow.OtherType.All.ToList());              //11
        //}

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

        private void MyMethod()
        {
            var selected = ComboBoxTeacherInfo.SelectedItem as TeacherInfo;

            if(selected == null) 
                return;

            var listReportK2S = new List<ReportK2>();

            foreach (var load in selected.TeacherLoad)
            {
                var reportK2 = new ReportK2();

                reportK2.TeacherName = load.TeacherInfo.Initials;
                reportK2.SubjectName = load.Subject.ShortName;

                var firstOrDefault = load.Subject.Flow.Group.FirstOrDefault();

                if (firstOrDefault != null)
                    reportK2.Course = firstOrDefault.Course;

                reportK2.EducationForm = load.Subject.Flow.EduForm;

                reportK2.FlowOrSubGroup = load.SubGroup != null ? load.SubGroup.Name : load.Subject.Flow.Name;

                reportK2.TeacherLoad = load;

                reportK2.TotalB = load.TotalHoursB;
                reportK2.TotalC = load.TotalHoursK;

                listReportK2S.Add(reportK2);
            }

            var reportK2OtherType = new ReportK2();

            foreach (var type in selected.TeacherLoadOtherType)
            {
                var firstOrDefault = type.OtherType.Flow.Group.FirstOrDefault();
                if (firstOrDefault != null)
                    reportK2OtherType.Course = firstOrDefault.Course;

                reportK2OtherType.EducationForm = type.OtherType.Flow.EduForm;
                reportK2OtherType.FlowOrSubGroup = type.OtherType.Flow.Name;
          
                switch (type.OtherType.TypeWork)
                {
                    case TypeWork.Керівництво_практикою:
                        reportK2OtherType.KerPrB += type.CountHoursB;
                        reportK2OtherType.KerPrK += type.CountHoursC;
                        break;
                    case TypeWork.Керівництво_атестац_роб:
                        if (type.OtherType.SubTypeWork == SubTypeWork.бакалаврів)
                        {
                            reportK2OtherType.KerBakB = type.CountHoursB;
                            reportK2OtherType.KerBakK = type.CountHoursC;
                        }
                        else if (type.OtherType.SubTypeWork == SubTypeWork.спеціалістів)
                        {
                            reportK2OtherType.KerSpB = type.CountHoursB;
                            reportK2OtherType.KerSpK = type.CountHoursC;
                        }
                        else if (type.OtherType.SubTypeWork == SubTypeWork.магістрів)
                        {
                            reportK2OtherType.KerMagB = type.CountHoursB;
                            reportK2OtherType.KerMagK = type.CountHoursC;
                        }
                        break;
                    case TypeWork.Керівництво:
                        if (type.OtherType.SubTypeWork == SubTypeWork.аспірантами)
                        {
                            reportK2OtherType.KerAspB = type.CountHoursB;
                            reportK2OtherType.KerAspK = type.CountHoursC;
                        }
                        break;
                    case TypeWork.Рецензування_атестац_роб:
                        reportK2OtherType.ReB += type.CountHoursB;
                        reportK2OtherType.ReK += type.CountHoursC;
                        break;
                    case TypeWork.Роб_в_ДЕК_захист_дипл:
                    case TypeWork.Роб_в_ДЕК_екзам_усн:
                    case TypeWork.Роб_в_ДЕК_екзам_пис:
                    case TypeWork.Роб_в_ДЕК_екзам:
                        reportK2OtherType.WorkB += type.CountHoursB;
                        reportK2OtherType.WorkK += type.CountHoursC;
                        break;
                }
            }

            reportK2OtherType.TotalB = reportK2OtherType.KerPrB + reportK2OtherType.KerBakB + reportK2OtherType.KerSpB +
                                       reportK2OtherType.KerMagB + reportK2OtherType.KerAspB + reportK2OtherType.ReB +
                                       reportK2OtherType.WorkB;

            reportK2OtherType.TotalC = reportK2OtherType.KerPrK + reportK2OtherType.KerBakK + reportK2OtherType.KerSpK +
                                       reportK2OtherType.KerMagK + reportK2OtherType.KerAspK + reportK2OtherType.ReK +
                                       reportK2OtherType.WorkK;

            listReportK2S.Add(reportK2OtherType);

            DataGridK2.ItemsSource = listReportK2S;
        }

        private void CreateK2Button_Click(object sender, RoutedEventArgs e)
        {

            if (K2.IsChecked == true)
            {
                if (ComboBoxTeacherInfo.SelectedItem != null)
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreateK2Async(ComboBoxTeacherInfo.SelectedItem.ToString(), _listOfTables);
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
                Task task = _reportsCreator.CreatePlanAllTotalAsync(null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (PlanAll.IsChecked == true)
            {
                if (ComboBoxTeacherInfo.SelectedItem != null)
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreatePlanAllAsync(ComboBoxTeacherInfo.SelectedItem.ToString(), _listOfTables);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    MessageBox.Show("Виберіть викладача!");
                }
            }
            else if (PaymentSum.IsChecked == true)
            {
                if (isFullCheckBox.IsChecked == true)
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreatePaymentSumAsync(true, null);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreatePaymentSumAsync(false, null);
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

        }

        private void CreateK4Button_Click(object sender, RoutedEventArgs e)
        {
            if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[0])
            {
                ProgressBar.IsIndeterminate = true;
                Task task = _reportsCreator.CreateK4Async(EduType.Budget, null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (EduTypeK4Combobox.SelectedItem == EduTypeK4Combobox.Items[1])
            {
                ProgressBar.IsIndeterminate = true;
                Task task = _reportsCreator.CreateK4Async(EduType.Contract, null);
                task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                ProgressBar.IsIndeterminate = true;
                _reportsCreator.CreateK4Async(EduType.Budget, null);
                Task task = _reportsCreator.CreateK4Async(EduType.Contract, null);
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
                    Task task = _reportsCreator.CreateK5Async(TermK5Combobox.Items[0].ToString(), EduType.Budget, null);           // Budget I semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[1])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreateK5Async(TermK5Combobox.Items[1].ToString(), EduType.Budget, null);           // Budget II semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[2])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreateK5Async(TermK5Combobox.Items[2].ToString(), EduType.Budget, null);           // Budget All
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
                    Task task = _reportsCreator.CreateK5Async(TermK5Combobox.Items[0].ToString(), EduType.Contract, null);           // Contract I semestr
                    task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (TermK5Combobox.SelectedItem == TermK5Combobox.Items[1])
                {
                    ProgressBar.IsIndeterminate = true;
                    Task task = _reportsCreator.CreateK5Async(TermK5Combobox.Items[1].ToString(), EduType.Contract, null);           // Contract II semestr
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
            Task task = _reportsCreator.CreateLoadDistributionAsync(DisciplineCombobox.SelectedValue.ToString(), null);
            task.ContinueWith(t => ProgressBar.IsIndeterminate = false, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CreateDisciplineButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;
            Task task = _reportsCreator.CreatePlanAllDisciplineAsync(null);
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyMethod();
        }
    }
}
