using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Reports
{
    public abstract class ExcelPageBuilder
    {
        protected byte[] file;
        public Excel.Application App { get; protected set; }
        public Excel.Workbook Book { get; protected set; }
        public Excel.Worksheet Sheet { get; protected set; }

        public ExcelPageBuilder()
        {
            App = new Excel.Application();
        }

        public abstract void CreateTemplate();
        public abstract void CreateBody();
        public abstract object[] GetExcelDocument();

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        } 

    }
}
