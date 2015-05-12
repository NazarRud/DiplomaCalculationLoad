using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MigraDoc;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Reports.ReportPages
{
    public class K2Page6BuilderPDF : PDFPageBuilder
    {
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("1. Викладання навчальних дисциплін").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 15;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("Контрольні заходи").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 15;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("Заліки").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;
            cell = row.Cells[4];
            cell.AddParagraph("Контрольні роботи\n(модульн., темат.)").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;
            cell = row.Cells[8];
            cell.AddParagraph("Курсові проекти").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;
            cell = row.Cells[12];
            cell.AddParagraph("Курсові роботи").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            sbyte currentCell = -2;
            for (int i = 0; i < 8; i++)
            {
                currentCell += 2;
                if (i % 2 == 0)
                {
                    cell = row.Cells[currentCell];
                    GetVerticalText(cell.AddTextFrame()).AddParagraph("\nза\n бюджетом").Format.Alignment = ParagraphAlignment.Center;
                    cell.MergeRight = 1;
                    continue;
                }
                cell = row.Cells[currentCell];
                GetVerticalText(cell.AddTextFrame()).AddParagraph("\nза\n контрактом").Format.Alignment = ParagraphAlignment.Center;
                cell.MergeRight = 1;
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    cell = row.Cells[i];
                    cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
                    continue;
                }
                cell = row.Cells[i];
                cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            currentCell = -2;
            for (int i = 0; i < 8; i++)
            {
                currentCell += 2;
                cell = row.Cells[currentCell];
                cell.AddParagraph((i + 25).ToString()).Format.Alignment = ParagraphAlignment.Center;
                cell.MergeRight = 1;
            }
        }

        public override void CreateBody()
        {
            throw new NotImplementedException();
        }

        public override void CreateAdditionalElement()
        {
            for (int i = 1; i < 41; i++)
            {
                if (i > 36 || i == 18 || i == 19)
                {
                    row = table.AddRow();
                    row.VerticalAlignment = VerticalAlignment.Center;
                    row.Shading.Color = Colors.LightGray;
                }
                else
                {
                    row = table.AddRow();
                    row.VerticalAlignment = VerticalAlignment.Center;
                }
            }
        }

        public override MigraDoc.DocumentObjectModel.Document GetPDFDocument()
        {
            document.DefaultPageSetup.Orientation = Orientation.Portrait;
            document.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(0.5);

            Styles styles = new Styles();
            styles.Normal.Font.Name = "Segoe UI";
            styles.Normal.Font.Size = Unit.FromCentimeter(0.3);
            document.Styles = styles;

            section = document.AddSection();        // Add a section to the document

            CreateHeader();
            //CreateBody();
            CreateAdditionalElement();
            section.Add(table);

            return document;
        }
    }
}
