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

//using Reports;
//using Reports.ReportPages;
//using Reports.ReportType;
//using Reports.SaveFormats;

namespace WPFClient.ReportsForm
{
    /// <summary>
    /// Логика взаимодействия для FormK2Report.xaml
    /// </summary>
    public partial class FormK2Report : Window
    {
        public FormK2Report()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Report report = new K2Report(new PDFSaver("K2_Page_4"), new K2Page4BuilderPDF());
            //report.CreateReport();
        }
    }
}
