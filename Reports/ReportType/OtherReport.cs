using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.ReportType
{
    class OtherReport : Report
    {
        private OtherReport()
        {
        }

        public OtherReport(Saver saver, PDFPageBuilder builder)
            : base(saver, builder)
        {
        }

        public override void CreateReport()
        {
            saver.SaveDocument(director.GetPDFDocument());
        }

    }
}
