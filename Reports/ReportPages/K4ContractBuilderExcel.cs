using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Reports.ReportPages
{
    public class K4ContractBuilderExcel : ExcelPageBuilder
    {
        public override void CreateTemplate()
        {
            this.file = Templates.K4_Contract;
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
    }
}
