using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Reports
{
    abstract class Report
    {
        protected Saver saver = null;
        protected PDFPageBuilder pdfBuilder = null;
        protected ExcelPageBuilder excelBuilder = null;
        protected CreatingDirector director = null;

        protected Report()
        {
        }

        public Report(Saver saver, PDFPageBuilder builder)
        {
            this.saver = saver;
            this.pdfBuilder = builder;
            this.director = new CreatingDirector(this.pdfBuilder);
        }

        public Report(Saver saver, ExcelPageBuilder builder)
        {
            this.saver = saver;
            this.excelBuilder = builder;
            this.director = new CreatingDirector(this.excelBuilder);
        }

        public abstract void CreateReport();

    }
}
