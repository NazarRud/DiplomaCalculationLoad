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
    public class PlanAllOnlyTotalResultsBuilderPDF : PDFPageBuilder
    {
        public override void CreateAdditionalElement()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.4));
            column = table.AddColumn(Unit.FromCentimeter(1.8));
            column = table.AddColumn(Unit.FromCentimeter(0.35));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            column = table.AddColumn(Unit.FromCentimeter(1.8));

            for (int i = 0; i < 35; i++)
            {
                column = table.AddColumn(Unit.FromCentimeter(0.62));
            }

            column = table.AddColumn(Unit.FromCentimeter(0.655));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            column.Borders.Left.Width = 1.5;
            column = table.AddColumn(Unit.FromCentimeter(0.8));

            table.BottomPadding = 2;
            table.TopPadding = 2;
        }

        public override void CreateHeader()
        {
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("№").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[1];
            cell.AddParagraph("Дисципліна").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[2];
            TextFrame fr = GetVerticalText(cell.AddTextFrame());
            fr.MarginLeft = -5;
            fr.AddParagraph("Курс").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[3];
            cell.AddParagraph("Фор-ма навч.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[4];
            cell.AddParagraph("Потік/Група").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[5];
            cell.AddParagraph("К-сть\nстуд.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[7];
            cell.AddParagraph("Лекції").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[9];
            cell.AddParagraph("Практ.\nзан.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[11];
            cell.AddParagraph("Лаб.\nзан.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[13];
            cell.AddParagraph("Іспит").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[15];
            cell.AddParagraph("Залік").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[17];
            cell.AddParagraph("МКР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[19];
            cell.AddParagraph("Курс.пр /роб.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[21];
            cell.AddParagraph("РГР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[23];
            cell.AddParagraph("ДКР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[25];
            cell.AddParagraph("Кон-сульт.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[27];
            cell.AddParagraph("Кер. практ.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[29];
            cell.AddParagraph("Керівництво").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 7;
            cell = row.Cells[37];
            cell.AddParagraph("Рецен-зув.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[39];
            cell.AddParagraph("Робота\nв ДЕК").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[41];
            cell.AddParagraph("Всього").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[29];
            cell.AddParagraph("Бак.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[31];
            cell.AddParagraph("Спец.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[33];
            cell.AddParagraph("Маг.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[35];
            cell.AddParagraph("Аспіра нт.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            for (int i = 0; i < 38; i++)
            {
                cell = row.Cells[i + 5];
                if ((i + 5) % 2 == 0)
                {
                    cell.AddParagraph("К").Format.Alignment = ParagraphAlignment.Center;
                    continue;
                }
                cell.AddParagraph("Б").Format.Alignment = ParagraphAlignment.Center;
            }
        }

        public override void CreateBody()
        {

            for (int i = 0; i < 20; i++)
            {
                if (i % 3 == 0)
                {
                    CreateHeader();
                }

                row = table.AddRow();
                cell = row.Cells[0];
                cell.MergeRight = 41;
                //row.Borders.Left.Width = 0;
                //row.Borders.Right.Width = 0;
                //row.Borders.Bottom.Width = 0;
                row.Borders.Width = 0;
                row.Borders.Left.Width = 0;

                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                //row.Borders.Left.Width = 0;
                //row.Borders.Right.Width = 0;
                //row.Borders.Top.Width = 0;
                row.Borders.Width = 0;
                row.Borders.Left.Width = 0;
                cell = row.Cells[0];
                cell.AddParagraph("=====> Teacher " + (i + 1) + "<=====").Format.Alignment = ParagraphAlignment.Left;
                cell.MergeRight = 41;
                cell.Format.Font.Bold = true;
                cell.Format.Font.Color = Colors.Green;

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("Разом за семестр 1").Format.Alignment = ParagraphAlignment.Left;
                cell.MergeRight = 41;
                //row.Borders.Left.Width = 0;
                //row.Borders.Right.Width = 0;
                //row.Borders.Bottom.Width = 0;
                row.Borders.Width = 0;
                row.Borders.Left.Width = 0;

                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                row.Shading.Color = Colors.LightGray;

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("Разом за семестр 2").Format.Alignment = ParagraphAlignment.Left;
                cell.MergeRight = 41;
                //row.Borders.Left.Width = 0;
                //row.Borders.Right.Width = 0;
                //row.Borders.Bottom.Width = 0;
                row.Borders.Width = 0;
                row.Borders.Left.Width = 0;

                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                row.Shading.Color = Colors.LightGray;

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("Всього:").Format.Alignment = ParagraphAlignment.Left;
                cell.MergeRight = 41;
                //row.Borders.Left.Width = 0;
                //row.Borders.Right.Width = 0;
                //row.Borders.Bottom.Width = 0;
                row.Borders.Width = 0;
                row.Borders.Left.Width = 0;

                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                row.Shading.Color = Colors.Yellow;
                
            }
         
        }

        public override MigraDoc.DocumentObjectModel.Document GetPDFDocument()
        {
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            document.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(0.5);

            Styles styles = new Styles();
            styles.Normal.Font.Name = "Segoe UI";
            styles.Normal.Font.Size = Unit.FromCentimeter(0.3);
            document.Styles = styles;

            section = document.AddSection();        // Add a section to the document

            CreateAdditionalElement();
            //CreateHeader();
            CreateBody();
            //CreateFooter();
            //CreateRightSideBody();
            section.Add(table);


            return document;
        }
    }
}
