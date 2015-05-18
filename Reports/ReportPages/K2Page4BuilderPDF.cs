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

using MigraDoc.DocumentObjectModel.Shapes;

namespace Reports.ReportPages
{
    class K2Page4BuilderPDF : PDFPageBuilder
    {
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.7));
            column = table.AddColumn(Unit.FromCentimeter(3));
            column = table.AddColumn(Unit.FromCentimeter(1.2));

            column = table.AddColumn(Unit.FromCentimeter(1.5));
            column = table.AddColumn(Unit.FromCentimeter(1));

            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));

            column = table.AddColumn(Unit.FromCentimeter(2.5));

            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(1));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[3];
            cell.AddParagraph("Характеристика груп та потоків").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 11;
            cell = row.Cells[0];
            cell.AddParagraph("№\nп/п").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 3;
            cell = row.Cells[1];
            cell.AddParagraph("Назва\nнавчальних\nдисциплін,\nїх загальний\nобсяг у годинах").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 3;
            cell = row.Cells[2];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Обсяг дисциплін за семестр").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[3];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Факультет(ін-тут), який забезпечується(абр.)").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[4];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Курс навчання").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[5];
            cell.AddParagraph("К-сть груп та підгруп").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 5;
            cell = row.Cells[11];
            cell.AddParagraph("Шифр\nгруп").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[12];
            cell.AddParagraph("К-сть студ.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[14];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("К-сть бюджет. потоків").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[15];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("К-сть контракт. потоків").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[5];
            cell.AddParagraph("Бюджетні").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 2;
            cell = row.Cells[8];
            cell.AddParagraph("Контрактні").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 2;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[5];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Академічні\nгрупи").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[6];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Підгрупи для\nпракт. занять").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[7];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Підгрупи для\nлаб. занять").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[8];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Академічні\nгрупи").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[9];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Підгрупи для\nпракт. занять").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[10];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("Підгрупи для\nлаб. занять").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[12];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("За бюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[13];
            GetVerticalText(cell.AddTextFrame()).AddParagraph("За контрактом").Format.Alignment = ParagraphAlignment.Center;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            for (int i = 0; i < 16; i++)
            {
                cell = row.Cells[i];
                cell.AddParagraph((i + 1).ToString()).Format.Alignment = ParagraphAlignment.Center;
            }
        }

        public override void CreateBody()
        {
            //throw new NotImplementedException();
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
                    cell = row.Cells[0];
                    cell.AddParagraph((i + 1).ToString()).Format.Alignment = ParagraphAlignment.Center;
                }
            }
            cell = column[22].Row[1];
            cell.AddParagraph("Разом за І семестр").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;

            cell = column[22].Row[3];
            cell.AddParagraph("за держбюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;

            cell = column[23].Row[3];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;

            cell = column[41].Row[1];
            cell.AddParagraph("Разом за ІІ семестр").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;

            cell = column[41].Row[3];
            cell.AddParagraph("за держбюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;

            cell = column[42].Row[3];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;

            cell = column[43].Row[1];
            cell.AddParagraph("Всього за\nнавчальний рік").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;

            cell = column[43].Row[3];
            cell.AddParagraph("за держбюджетом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;

            cell = column[44].Row[3];
            cell.AddParagraph("за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 12;
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
            CreateAdditionalElement();
            //CreateBody();
            section.Add(table);

            return document;
        }
    }
}
