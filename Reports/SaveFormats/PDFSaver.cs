using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Reports.SaveFormats
{
    class PDFSaver : Saver
    {
        
        private PDFSaver()
        {
        }

        public PDFSaver(string fileName)
        {
            this.fileName = fileName;
        }

        public override void SaveDocument(Document document)
        {
            InitDirectoryStructure();

            document.UseCmykColor = true;

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            pdfRenderer.PdfDocument.Save(Environment.CurrentDirectory + @"\Звіти\Поточні\" + Enum.GetName(typeof(Monthes), DateTime.Now.Month) + " " + DateTime.Now.Year + @"\" + fileName + ".pdf");

            // ...and start a viewer.
            //Process.Start(String.Format("{0}.pdf", fileName));
        }
    }
}
