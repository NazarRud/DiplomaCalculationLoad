using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.ReportType
{
    class K5Report : Report
    {
        private K5Report()
        {
        }

        public K5Report(Saver saver, ExcelPageBuilder builder)
            : base(saver, builder)
        {
        }
        public override void CreateReport()
        {
            saver.SaveDocument(director.GetExcelDocument());
        }
    }
}
