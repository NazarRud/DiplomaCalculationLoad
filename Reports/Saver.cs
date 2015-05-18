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
    abstract class Saver
    {
        protected string fileName;
        public virtual void SaveDocument(object[] document) { }
        public virtual void SaveDocument(Document document) { }
    }
}
