using System;
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
        private Report report;
        public void CreateK2()
        {
            report = new K2Report(new PDFSaver("K2_Page_4"), new K2Page4BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("K2_Page_5"), new K2Page5BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("K2_Page_6"), new K2Page6BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("K2_Page_7"), new K2Page7BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("K2_Page_8"), new K2Page8BuilderPDF());
            report.CreateReport();
            report = new K2Report(new PDFSaver("K2_Page_9"), new K2Page9BuilderPDF());
            report.CreateReport();
        }

        public Task CreateK2Async()
        {
            return Task.Factory.StartNew(CreateK2);            
        }

        public void CreateK4(EduType type)
        {
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
                report = new K4Report(new ExcelSaver("K4_Contract"), new K4BudgetBuilderExcel());
                report.CreateReport();
            }
        }

        public Task CreateK4Async(EduType type)
        {
            return Task.Factory.StartNew(() => CreateK4(type));
        }

        public void CreateK5(EduType type)
        {
            if (type == EduType.Budget)
            {
                report = new K5Report(new ExcelSaver("K5_Budget"), new K5BudgetBuilderExcel());
                report.CreateReport();
            }
            else if (type == EduType.Contract)
            {
                report = new K5Report(new ExcelSaver("K5_Contract"), new K5ContractBuilderExcel());
                report.CreateReport();
            }
            else
            {
                report = new K5Report(new ExcelSaver("K5_Budget"), new K5BudgetBuilderExcel());
                report.CreateReport();
                report = new K5Report(new ExcelSaver("K5_Contract"), new K5BudgetBuilderExcel());
                report.CreateReport();
            }
        }

        public Task CreateK5Async(EduType type)
        {
            return Task.Factory.StartNew(() => CreateK5(type));
        }

        public void CreateLoadDistribution(string discipline)
        {
            report = new OtherReport(new PDFSaver("LD"), new LoadDistributionBuilderPDF(discipline));
            report.CreateReport();
        }

        public Task CreateLoadDistributionAsync(string discipline)
        {
            return Task.Factory.StartNew(() => CreateLoadDistribution(discipline));    
        }

        public void CreatePlanAll()
        {
            report = new OtherReport(new PDFSaver("Plan_all"), new PlanAllBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllAsync()
        {
            return Task.Factory.StartNew(CreatePlanAll);    
        }

        public void CreatePlanAllTotal()
        {
            report = new OtherReport(new PDFSaver("Plan_All_Total_Results"), new PlanAllOnlyTotalResultsBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllTotalAsync()
        {
            return Task.Factory.StartNew(CreatePlanAllTotal);            
        }

        public void CreatePlanAllDiscipline()
        {
            report = new OtherReport(new PDFSaver("Plan_All_Discipline"), new PlanAllDisciplineBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePlanAllDisciplineAsync()
        {
            return Task.Factory.StartNew(CreatePlanAllDiscipline);            
        }

        public void CreatePaymentSum()
        {
            report = new OtherReport(new PDFSaver("Payment_Sum"), new PaymentSumBuilderPDF());
            report.CreateReport();
        }

        public Task CreatePaymentSumAsync()
        {
            return Task.Factory.StartNew(CreatePaymentSum); 
        }


    }
}
