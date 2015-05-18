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

namespace Reports.ReportPages
{
    class K2Page8BuilderPDF : PDFPageBuilder
    {
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.8));

            column = table.AddColumn(Unit.FromCentimeter(1.2));
            column = table.AddColumn(Unit.FromCentimeter(2.4));
            column = table.AddColumn(Unit.FromCentimeter(2.9));

            column = table.AddColumn(Unit.FromCentimeter(2.2));
            column = table.AddColumn(Unit.FromCentimeter(1));
            column = table.AddColumn(Unit.FromCentimeter(2.8));

            column = table.AddColumn(Unit.FromCentimeter(1.1));
            column = table.AddColumn(Unit.FromCentimeter(1.1));

            column = table.AddColumn(Unit.FromCentimeter(1.1));
            column = table.AddColumn(Unit.FromCentimeter(1.1));
            column = table.AddColumn(Unit.FromCentimeter(1.1));
            column = table.AddColumn(Unit.FromCentimeter(1.1));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph("Інші види навчальної роботи - І семестр").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 11;
            cell = row.Cells[0];
            cell.AddParagraph("№\nп/п").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[1];
            cell.AddParagraph("Вид роботи").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell.MergeRight = 2;  // Delete for part 2 semestr
            cell = row.Cells[4];
            cell.AddParagraph("Факультет\n(інститут)").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[5];
            cell.AddParagraph("Курс").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[6];
            cell.AddParagraph("Шифр\nгруп").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[7];
            cell.AddParagraph("К-сть студ.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            // Merge with 8 cell!!!!!!!!!!!!!!
            cell = row.Cells[9];
            cell.AddParagraph("Всього годин").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[7];
            cell.AddParagraph("Б").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;
            cell = row.Cells[8];
            cell.AddParagraph("К").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 1;
            cell = row.Cells[9];
            cell.AddParagraph("Бюджет").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[11];
            cell.AddParagraph("Контракт").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[9];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[10];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[11];
            cell.AddParagraph("пл").Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[12];
            cell.AddParagraph("вик").Format.Alignment = ParagraphAlignment.Center;
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

            cell = column[4].Row[1];
            cell.MergeDown = 2;
            cell.MergeRight = 1;
            cell.AddParagraph("Індивідуальні\nзаняття").Format.Alignment = ParagraphAlignment.Center;
            cell = column[4].Row[3];
            cell.AddParagraph("зі студентами").Format.Alignment = ParagraphAlignment.Center;
            cell = column[5].Row[3];
            cell.MergeDown = 1;
            cell.AddParagraph("з магістрами").Format.Alignment = ParagraphAlignment.Center;
            cell = column[5].Row[5];
            cell.AddParagraph("5").Format.Alignment = ParagraphAlignment.Center;
            cell = column[6].Row[5];
            cell.AddParagraph("6").Format.Alignment = ParagraphAlignment.Center;

            cell = column[7].Row[1];
            cell.MergeRight = 1;
            cell.MergeDown = 3;
            cell.AddParagraph("Керівництво\nпрактикою").Format.Alignment = ParagraphAlignment.Center;

            cell = column[11].Row[1];
            cell.MergeDown = 2;
            cell.MergeRight = 1;
            cell.AddParagraph("Керівництво\nатестац. роботами").Format.Alignment = ParagraphAlignment.Center;
            cell = column[11].Row[3];
            cell.AddParagraph("бакалаврів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[12].Row[3];
            cell.AddParagraph("спеціалістів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[13].Row[3];
            cell.AddParagraph("магістрів").Format.Alignment = ParagraphAlignment.Center;

            cell = column[14].Row[1];
            cell.MergeDown = 2;
            cell.MergeRight = 1;
            cell.AddParagraph("Консультування\nатестац. робіт").Format.Alignment = ParagraphAlignment.Center;
            cell = column[14].Row[3];
            cell.AddParagraph("бакалаврів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[15].Row[3];
            cell.AddParagraph("спеціалістів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[16].Row[3];
            cell.AddParagraph("магістрів").Format.Alignment = ParagraphAlignment.Center;

            cell = column[17].Row[1];
            cell.MergeDown = 2;
            cell.MergeRight = 1;
            cell.AddParagraph("Рецензування\nатестац. робіт").Format.Alignment = ParagraphAlignment.Center;
            cell = column[17].Row[3];
            cell.AddParagraph("бакалаврів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[18].Row[3];
            cell.AddParagraph("спеціалістів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[19].Row[3];
            cell.AddParagraph("магістрів").Format.Alignment = ParagraphAlignment.Center;

            cell = column[20].Row[1];
            cell.MergeDown = 1;
            cell.MergeRight = 1;
            cell.AddParagraph("Консультування\nперед держ. екзам.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[20].Row[3];
            cell.AddParagraph("бакалаврів").Format.Alignment = ParagraphAlignment.Center;
            cell = column[21].Row[3];
            cell.AddParagraph("спеціалістів").Format.Alignment = ParagraphAlignment.Center;

            cell = column[22].Row[1];
            cell.MergeDown = 5;
            cell.AddParagraph("Робота в\nДЕК").Format.Alignment = ParagraphAlignment.Center;
            cell = column[22].Row[2];
            cell.AddParagraph("захист дипл.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[23].Row[2];
            cell.AddParagraph("екзам. усний").Format.Alignment = ParagraphAlignment.Center;
            cell = column[24].Row[2];
            cell.AddParagraph("екзам. письм.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[25].Row[2];
            cell.AddParagraph("захист дипл.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[26].Row[2];
            cell.AddParagraph("екзамен").Format.Alignment = ParagraphAlignment.Center;
            cell = column[27].Row[2];
            cell.AddParagraph("захист дипл.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[22].Row[3];
            cell.MergeDown = 2;
            cell.AddParagraph("бакалаври").Format.Alignment = ParagraphAlignment.Center;
            cell = column[25].Row[3];
            cell.MergeDown = 1;
            cell.AddParagraph("спеціалісти").Format.Alignment = ParagraphAlignment.Center;
            cell = column[27].Row[3];
            cell.AddParagraph("магістри").Format.Alignment = ParagraphAlignment.Center;

            cell = column[28].Row[1];
            cell.MergeDown = 1;
            cell.MergeRight = 1;
            cell.AddParagraph("Керівництво").Format.Alignment = ParagraphAlignment.Center;
            cell = column[28].Row[3];
            cell.AddParagraph("аспірантами").Format.Alignment = ParagraphAlignment.Center;
            cell = column[29].Row[3];
            cell.AddParagraph("здобув., стаж").Format.Alignment = ParagraphAlignment.Center;

            cell = column[30].Row[1];
            cell.MergeDown = 2;
            cell.AddParagraph("Заняття з аспіран.").Format.Alignment = ParagraphAlignment.Center;
            cell = column[30].Row[2];
            cell.MergeRight = 1;
            cell.AddParagraph("лекції").Format.Alignment = ParagraphAlignment.Left;
            cell = column[31].Row[2];
            cell.MergeRight = 1;
            cell.AddParagraph("семінари, практ. заняття").Format.Alignment = ParagraphAlignment.Left;
            cell = column[32].Row[2];
            cell.MergeRight = 1;
            cell.AddParagraph("консульт., реценз., екзам.").Format.Alignment = ParagraphAlignment.Left;

            cell = column[33].Row[1];
            cell.MergeRight = 2;
            cell.AddParagraph("Консультування докторантів").Format.Alignment = ParagraphAlignment.Left;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[1];
            cell.MergeRight = 2;
            cell.AddParagraph("Всього").Format.Alignment = ParagraphAlignment.Right;

        }

        public override void CreateBody()
        {
            // There will be generated body info!!!!!
        }

        //TODO: Refactor Method GetDocument in K2 Page8
        public override MigraDoc.DocumentObjectModel.Document GetPDFDocument()
        {
            // Create a new MigraDoc document
            //document = new Document();
            document.DefaultPageSetup.Orientation = Orientation.Portrait;
            document.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(0.5);
            //document.DefaultPageSetup.PageFormat = PageFormat.A4;
            Styles styles = new Styles();
            styles.Normal.Font.Name = "Segoe UI";
            styles.Normal.Font.Size = Unit.FromCentimeter(0.3);
            document.Styles = styles;

            // Add a section to the document
            section = document.AddSection();


            CreateHeader();
            CreateLeftSideBody();
            //CreateBody();


            section.Add(table);


            //Paragraph paragraph = section.AddParagraph("\n\n\nРАЗОМ НАВЧАЛЬНЕ НАВАНТАЖЕННЯ (годин)");
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Alignment = ParagraphAlignment.Center;

            return document;
        }


    }
}
