using System;
using System.Collections;
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
using MigraDoc.DocumentObjectModel.Shapes;
using Reports.Public;

namespace Reports
{
    abstract class PDFPageBuilder
    {
        protected Document document;
        protected Section section;
        protected Table table;
        protected Column column;
        protected Row row;
        protected Cell cell;
        protected ICollection renderBody;

        public PDFPageBuilder()
        {
            document = new Document();
            table = new Table();
            column = new Column();
            row = new Row();
            cell = new Cell();
            renderBody = ReportsCreator.renderBody;
            InitDocumentSettings();
        }

        private void InitDocumentSettings()
        {
            table.Borders.Width = 0.2;
            table.Borders.Color = Color.FromRgbColor(255, Colors.Black);
            table.BottomPadding = 1;
            table.TopPadding = 1;
            row.VerticalAlignment = VerticalAlignment.Center;
            cell.Format.Alignment = ParagraphAlignment.Center;
        }

        public TextFrame GetVerticalText(TextFrame frame)
        {
            frame.Orientation = TextOrientation.Upward;
            frame.WrapFormat.Style = WrapStyle.None;
            return frame;
        }
        public abstract void CreateHeader();
        public abstract void CreateBody();
        public virtual void CreateLeftSideBody() { }
        public virtual void CreateRightSideBody() { }
        public virtual void CreateFooter() { }
        public virtual void CreateAdditionalElement() { }
        public abstract Document GetPDFDocument();

    }
}
