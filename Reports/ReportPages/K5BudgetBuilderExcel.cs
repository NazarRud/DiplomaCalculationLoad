using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Reports.ReportPages
{
    public class K5BudgetBuilderExcel : ExcelPageBuilder
    {
        public override void CreateTemplate()
        {
            this.file = Templates.K5_Budget;
            File.WriteAllBytes(Environment.CurrentDirectory + "\\Temp.xls", file);
            Book = App.Workbooks.Open(Environment.CurrentDirectory + "\\Temp.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Sheet = (Excel.Worksheet)Book.Worksheets.get_Item(1);
        }
        public override void CreateBody()
        {
            for (int i = 0; i < 20; i++)
            {
                i++;
                Sheet.Cells[i + 10, 2] = "teacher " + i;
                Sheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
        }

        public override object[] GetExcelDocument()
        {
            CreateTemplate();
            CreateBody();

            return new object[]{
                Sheet,
                Book,
                App
            };
        }


        //public void CrExDoc(Excel.Worksheet sheet)
        //{
        //    sheet.Cells[2, 2] = "Кафедра автоматизованих систем обробки інформації та управління";
        //    sheet.Cells[3, 2] = "                                              (повна назва кафедри)";

        //}



    }
}
