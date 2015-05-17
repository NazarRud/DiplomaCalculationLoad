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

namespace WPFClient.ReportsForm
{
    /// <summary>
    /// Логика взаимодействия для FormReportsAll.xaml
    /// </summary>
    public partial class FormReportsAll : Window
    {
        List<string> teachList = new List<string>();

        public FormReportsAll()
        {
            InitializeComponent();
            InitCombo();
            //this.TeacherCombobox.SelectionChanged += new SelectionChangedEventHandler(TeacherCombobox_SelectionChanged);
        }     

        private void TeacherCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = TeacherCombobox.Text;
            //MessageBox.Show("changed" + s);
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

    }
}
