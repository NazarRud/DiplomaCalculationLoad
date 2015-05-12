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
    public class K2Page9BuilderPDF : PDFPageBuilder
    {
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.8));

            column = table.AddColumn(Unit.FromCentimeter(2.5));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(2.5));

            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));

            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));
            column = table.AddColumn(Unit.FromCentimeter(1.3));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph("Інші види навчальної роботи - ІI семестр").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 8;
            cell = row.Cells[10];
            cell.AddParagraph("Разом годин за рік").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 3;
            cell.MergeDown = 1;
            cell.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("№\nп/п").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[1];
            cell.AddParagraph("Факультет\n(інститут)").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[2];
            cell.AddParagraph("Курс").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[3];
            cell.AddParagraph("Шифр\nгруп").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[4];
            cell.AddParagraph("К-сть студ.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[6];
            cell.AddParagraph("Всього годин").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[4];
            cell.AddParagraph("Б").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;
            cell = row.Cells[5];
            cell.AddParagraph("К").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;
            cell = row.Cells[6];
            cell.AddParagraph("Бюджет").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[8];
            cell.AddParagraph("Контракт").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[10];
            cell.AddParagraph("Бюджет").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[12];
            cell.AddParagraph("Контракт").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[6];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[7];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[8];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[9];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[10];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[11];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[12];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[13];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
        }

        public override void CreateBody()
        {
            // There will be generated body info!!!!!
        }

        public override void CreateLeftSideBody()
        {
            for (int i = 0; i < 30; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                cell = row.Cells[0];
                cell.AddParagraph((i + 1).ToString()).Format.Alignment = ParagraphAlignment.Center;
            }
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[0];
            cell.MergeRight = 1;

            cell = column[5].Row[2];
            cell.AddParagraph("5").Format.Alignment = ParagraphAlignment.Center;
            cell = column[6].Row[2];
            cell.AddParagraph("6").Format.Alignment = ParagraphAlignment.Center;
        }

        public override void CreateFooter()
        {
            Paragraph paragraph = section.AddParagraph("\n\n\n\n\nРАЗОМ НАВЧАЛЬНЕ НАВАНТАЖЕННЯ (годин)\n\n");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            Table footerTable = new Table();
            footerTable.Borders.Width = 0.1;
            footerTable.BottomPadding = 1;
            footerTable.TopPadding = 1;
            footerTable.Borders.Color = Color.FromRgbColor(255, Colors.Black);

            column = footerTable.AddColumn(Unit.FromCentimeter(3));

            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));

            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));

            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));
            column = footerTable.AddColumn(Unit.FromCentimeter(1.33));

            for (int i = 0; i < 6; i++)
            {
                row = footerTable.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
            }

            cell = column[0].Row[0];
            cell.AddParagraph("Термін\nвиконання").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;
            cell = column[0].Row[1];
            cell.AddParagraph("Викладання\nнавчальних дисциплін").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;
            cell = column[0].Row[5];
            cell.AddParagraph("Інші види\nнавчальної роботи").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;
            cell = column[0].Row[9];
            cell.AddParagraph("Всього годин").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;

            cell = column[1].Row[1];
            cell.AddParagraph("за бюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = column[1].Row[3];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = column[1].Row[5];
            cell.AddParagraph("за бюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = column[1].Row[7];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = column[1].Row[9];
            cell.AddParagraph("за бюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = column[1].Row[11];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;

            cell = column[2].Row[1];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[2];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[3];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[4];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[5];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[6];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[7];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[8];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[9];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[10];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[11];
            cell.AddParagraph("план").Format.Alignment = ParagraphAlignment.Center;
            cell = column[2].Row[12];
            cell.AddParagraph("вик.").Format.Alignment = ParagraphAlignment.Center;

            cell = column[3].Row[0];
            cell.AddParagraph("I семестр").Format.Alignment = ParagraphAlignment.Center;
            cell = column[4].Row[0];
            cell.AddParagraph("II семестр").Format.Alignment = ParagraphAlignment.Center;
            cell = column[5].Row[0];
            cell.AddParagraph("Разом за рік").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;

            section.Add(footerTable);
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
            CreateLeftSideBody();
            //CreateBody();
            section.Add(table);
            CreateFooter();

            return document;
        }
    }
}
