using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.ReportType
{
    public class K4Report : Report
    {
        private K4Report()
        {
        }

        public K4Report(Saver saver, ExcelPageBuilder builder)
            : base(saver, builder)
        {
        }
        public override void CreateReport()
        {
            saver.SaveDocument(director.GetExcelDocument());
        }
    }
}
