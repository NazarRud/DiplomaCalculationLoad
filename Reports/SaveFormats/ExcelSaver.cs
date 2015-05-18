using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Reports.SaveFormats
{
    class ExcelSaver : Saver
    {
        private ExcelSaver()
        {
        }

        public ExcelSaver(string fileName)
        {
            this.fileName = fileName;
        }
        public override void SaveDocument(object[] document)
        {
            (document[1] as Excel.Workbook).Close(true, Environment.CurrentDirectory + "\\" + fileName + ".xls", null);
            (document[2] as Excel.Application).Quit();

            ExcelPageBuilder.ReleaseObject(document[0] as Excel.Application);
            ExcelPageBuilder.ReleaseObject(document[1] as Excel.Workbook);
            ExcelPageBuilder.ReleaseObject(document[2] as Excel.Application);
            File.Delete(Environment.CurrentDirectory + "\\Temp.xls");

            Process.Start(String.Format("{0}.xls", fileName));

        }

    }
}
