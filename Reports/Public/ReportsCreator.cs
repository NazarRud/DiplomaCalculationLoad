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
        internal static ICollection renderBody { get; set; }
        public static string CurrentYear { get; set; }
        private Report report;

        public void CreateK2(string teachersName, ICollection collection)
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

        public Task CreateK2Async(string teachersName, ICollection collection)
        {
            return Task.Factory.StartNew(() => CreateK2(teachersName, collection));            
        }

        public void CreateK4(EduType type, ICollection collection)
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

        public Task CreateK4Async(EduType type, ICollection collection)
        {
            return Task.Factory.StartNew(() => CreateK4(type, collection));
        }

        public void CreateK5(string term, EduType type, ICollection collection)
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

        public Task CreateK5Async(string term, EduType type, ICollection collection)
        {
            return Task.Factory.StartNew(() => CreateK5(term, type, collection));
        }

        public void CreateLoadDistribution(string discipline, ICollection collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("LD_(" + discipline + ")"), new LoadDistributionBuilderPDF(discipline));
            report.CreateReport();
        }

        public Task CreateLoadDistributionAsync(string discipline, ICollection collection)
        {
            return Task.Factory.StartNew(() => CreateLoadDistribution(discipline, collection));    
        }

        public void CreatePlanAll(ICollection collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_all"), new PlanAllBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllAsync(ICollection collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAll(collection));    
        }

        public void CreatePlanAllTotal(ICollection collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_All_Total_Results"), new PlanAllOnlyTotalResultsBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllTotalAsync(ICollection collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAllTotal(collection));            
        }

        public void CreatePlanAllDiscipline(ICollection collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Plan_All_Discipline"), new PlanAllDisciplineBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllDisciplineAsync(ICollection collection)
        {
            return Task.Factory.StartNew(() => CreatePlanAllDiscipline(collection));            
        }

        public void CreatePaymentSum(bool isFull, ICollection collection)
        {
            renderBody = collection;
            report = new OtherReport(new PDFSaver("Payment_Sum"), new PaymentSumBuilderPDF(isFull));
            report.CreateReport();
        }

        public Task CreatePaymentSumAsync(bool isFull, ICollection collection)
        {
            return Task.Factory.StartNew(() => CreatePaymentSum(isFull, collection)); 
        }


    }
}
