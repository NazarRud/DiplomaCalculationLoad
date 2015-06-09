using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reports.ReportPages;
using Reports.ReportType;
using Reports.SaveFormats;

namespace Reports.Public
{
    public class ReportsCreator
    {
        internal static ArrayList renderBody { get; set; }
        public static string CurrentYear { get; set; }
        private Report report;

        public void CreateK2(string teachersName, ArrayList collection)
        {
            renderBody = collection; 
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_4"), new K2Page4BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_5"), new K2Page5BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_6"), new K2Page6BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_7"), new K2Page7BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_8"), new K2Page8BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("(" + teachersName + ")_K2_Page_9"), new K2Page9BuilderPDF());
            report.CreateReport();
        }

        public Task CreateK2Async(string teachersName, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreateK2(teachersName, collection));            
        }

        public void CreateK4(EduType type, ArrayList collection)
        {
            renderBody = collection;
            if (type == EduType.Budget)
            {
                report = new K4Report(new ExcelSaver("K4_Budget"), new K4BudgetBuilderExcel());
                report.CreateReport();
            }
            else if(type == EduType.Contract)
            {
                report = new K4Report(new ExcelSaver("K4_Contract"), new K4ContractBuilderExcel());
                report.CreateReport();
            }
            else
            {
                report = new K4Report(new ExcelSaver("K4_Budget"), new K4BudgetBuilderExcel());
                report.CreateReport();
                report = new K4Report(new ExcelSaver("K4_Contract"), new K4ContractBuilderExcel());
                report.CreateReport();
            }
        }

        public Task CreateK4Async(EduType type, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreateK4(type, collection));
        }

        public void CreateK5(string term, EduType type, ArrayList collection)
        {
            renderBody = collection;
            if (type == EduType.Budget)
            {
                report = new K5Report(new ExcelSaver("K5_Budget_(" + term + ")"), new K5BudgetBuilderExcel());
                report.CreateReport();
            }
            else if (type == EduType.Contract)
            {
                report = new K5Report(new ExcelSaver("K5_Contract_(" + term + ")"), new K5ContractBuilderExcel());
                report.CreateReport();
            }
            else
            {
                report = new K5Report(new ExcelSaver("K5_Budget_(" + term + ")"), new K5BudgetBuilderExcel());
                report.CreateReport();
                report = new K5Report(new ExcelSaver("K5_Contract_(" + term + ")"), new K5ContractBuilderExcel());
                report.CreateReport();
            }
        }

        public Task CreateK5Async(string term, EduType type, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreateK5(term, type, collection));
        }

        public void CreateLoadDistribution(string discipline, ArrayList collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("LD_(" + discipline + ")"), new LoadDistributionBuilderPDF(discipline));
            report.CreateReport();
        }

        public Task CreateLoadDistributionAsync(string discipline, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreateLoadDistribution(discipline, collection));    
        }

        public void CreatePlanAll(string teacher, ArrayList collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_all_(" + teacher + ")"), new PlanAllBuilderPDF(teacher));
            report.CreateReport();
        }

        public Task CreatePlanAllAsync(string teacher, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAll(teacher, collection));    
        }

        public void CreatePlanAllTotal(ArrayList collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_All_Total_Results"), new PlanAllOnlyTotalResultsBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllTotalAsync(ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAllTotal(collection));            
        }

        public void CreatePlanAllDiscipline(ArrayList collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_All_Discipline"), new PlanAllDisciplineBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllDisciplineAsync(ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAllDiscipline(collection));            
        }

        public void CreatePaymentSum(bool isFull, ArrayList collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Payment_Sum"), new PaymentSumBuilderPDF(isFull));
            report.CreateReport();
        }

        public Task CreatePaymentSumAsync(bool isFull, ArrayList collection)
        {
            return Task.Factory.StartNew(() => CreatePaymentSum(isFull, collection)); 
        }


    }
}
