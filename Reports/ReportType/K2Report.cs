using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.ReportType
{
    public class K2Report : Report
    {
        private K2Report()
        {
        }

        public K2Report(Saver saver, PDFPageBuilder builder)
            : base(saver, builder)
        {
        }

        public override void CreateReport()
        {
            //PageBuilder builder = new K2Page8Builder();
            //CreatingDirector director = new CreatingDirector(builder);
            saver.SaveDocument(director.GetPDFDocument());

        }

    }
}
