using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    class CreatingDirector
    {
        private PDFPageBuilder ppb;
        private ExcelPageBuilder epb;
        public CreatingDirector(PDFPageBuilder builder)
        {
            this.ppb = builder;
        }

        public CreatingDirector(ExcelPageBuilder builder)
        {
            this.epb = builder;
        }

        public MigraDoc.DocumentObjectModel.Document GetPDFDocument()
        {
            return ppb.GetPDFDocument();
        }

        public object[] GetExcelDocument()
        {
            return epb.GetExcelDocument();
        }
    }
}
