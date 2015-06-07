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

using System.IO;

namespace Reports.ReportPages
{
    class PlanAllDisciplineBuilderPDF : PDFPageBuilder
    {
        private int availableRows = 30;
        List<FakeData> fakeData = FakeData.GetFakeData();
        List<FakeData> fd;

        public override void CreateAdditionalElement()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.35));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            column = table.AddColumn(Unit.FromCentimeter(2));
            column = table.AddColumn(Unit.FromCentimeter(2));

            for (int i = 0; i < 35; i++)
            {
                column = table.AddColumn(Unit.FromCentimeter(0.62));
            }

            column = table.AddColumn(Unit.FromCentimeter(0.655));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            //column.Borders.Left.Width = 1.5;
            column = table.AddColumn(Unit.FromCentimeter(0.8));

        }

        public override void CreateHeader()
        {
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            row.Borders.Top.Width = 0;
            cell = row.Cells[0];
            TextFrame fr = GetVerticalText(cell.AddTextFrame());
            fr.MarginLeft = -5;
            fr.AddParagraph("Курс").Format.Alignment = ParagraphAlignment.Center;
            cell.Borders.Left.Width = 0.2;
            cell.MergeDown = 2;
            cell = row.Cells[1];
            cell.AddParagraph("Фор-ма навч.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[2];
            cell.AddParagraph("Потік/Група").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[3];
            cell.AddParagraph("Викладач").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeDown = 2;
            cell = row.Cells[4];
            cell.AddParagraph("К-сть\nстуд.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[6];
            cell.AddParagraph("Лекції").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[8];
            cell.AddParagraph("Практ.\nзан.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[10];
            cell.AddParagraph("Лаб.\nзан.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[12];
            cell.AddParagraph("Іспит").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[14];
            cell.AddParagraph("Залік").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[16];
            cell.AddParagraph("МКР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[18];
            cell.AddParagraph("Курс.пр /роб.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[20];
            cell.AddParagraph("РГР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[22];
            cell.AddParagraph("ДКР").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[24];
            cell.AddParagraph("Кон-сульт.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[26];
            cell.AddParagraph("Кер. практ.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[28];
            cell.AddParagraph("Керівництво").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 7;
            cell = row.Cells[36];
            cell.AddParagraph("Рецен-зув.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[38];
            cell.AddParagraph("Робота\nв ДЕК").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell = row.Cells[40];
            cell.AddParagraph("Всього").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell.MergeDown = 1;
            cell.Borders.Left.Width = 1.5;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[28];
            cell.AddParagraph("Бак.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[30];
            cell.AddParagraph("Спец.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[32];
            cell.AddParagraph("Маг.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;
            cell = row.Cells[34];
            cell.AddParagraph("Аспіра нт.").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            for (int i = 0; i < 38; i++)
            {
                cell = row.Cells[i + 4];
                if (i == 36)
                    cell.Borders.Left.Width = 1.5;
                if ((i + 4) % 2 == 0)
                {
                    cell.AddParagraph("Б").Format.Alignment = ParagraphAlignment.Center;
                    continue;
                }
                cell.AddParagraph("К").Format.Alignment = ParagraphAlignment.Center;
            }

        }

        public override void CreateBody()
        {
            column.Borders.Left.Width = 0;
            for (int i = 0; i < fd.Count; i++)
            {
                if (availableRows == 30)
                {
                    //row = table.AddRow();
                    //row.Borders.Width = 0;
                    //cell = row.Cells[0];
                    //cell.Borders.Width = 0;
                    //cell.Borders.Left.Width = 0;
                    //cell.Borders.Right.Width = 0;
                    //availableRows -= 1;

                    CreateHeader();
                    availableRows -= 1;
                    row = table.AddRow();
                    row.Borders.Width = 0;
                    cell = row.Cells[0];
                    cell.AddParagraph("Семестр" + fd[i].Semestr).Format.Alignment = ParagraphAlignment.Left;
                    cell.Borders.Width = 0;
                    cell.Format.Font.Bold = true;
                    cell.Format.Font.Color = Colors.Green;
                    cell.MergeRight = 41;
                    availableRows -= 1;
                }
                else
                {
                    if (availableRows > fd[i].Teachers.Count + 2)
                    {
                        row = table.AddRow();
                        row.Borders.Width = 0;
                        cell = row.Cells[0];
                        cell.AddParagraph("Дисципліна").Format.Alignment = ParagraphAlignment.Left;
                        cell.Borders.Width = 0;
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.MergeRight = 41;
                        availableRows -= 1;

                        for (int j = 0; j < fd[i].Teachers.Count; j++)
                        {
                            row = table.AddRow();
                            cell = row.Cells[0];
                            cell.AddParagraph(fd[i].Course.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[1];
                            cell.AddParagraph(fd[i].EduForm.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[2];
                            cell.AddParagraph(fd[i].FlowAndGroup.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[3];
                            cell.AddParagraph(fd[i].Teachers[j].ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[40];
                            cell.Borders.Left.Width = 1.5;
                            availableRows -= 1;
                        }

                        row = table.AddRow();
                        row.Borders.Width = 0;
                        cell = row.Cells[0];
                        cell.AddParagraph("Всього:").Format.Alignment = ParagraphAlignment.Left;
                        cell.Borders.Width = 0;
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.MergeRight = 41;
                        availableRows -= 1;

                        row = table.AddRow();
                        row.Shading.Color = Colors.LightSkyBlue;
                        cell = row.Cells[0];
                        cell.AddParagraph("").Format.Alignment = ParagraphAlignment.Left;
                        cell = row.Cells[40];
                        cell.Borders.Left.Width = 1.5;
                        availableRows -= 1;
                    }
                    else
                    {

                        for (int i2 = 0; i2 < availableRows; i2++)
                        {
                            row = table.AddRow();
                            row.Borders.Width = 0;
                            //row.Shading.Color = Colors.LightGray;  //look unused rows
                            cell = row.Cells[0];
                            cell.MergeRight = 41;
                            cell.Borders.Width = 0;
                        }

                        //row = table.AddRow();
                        //row.Borders.Width = 0;
                        //cell = row.Cells[0];
                        //cell.Borders.Width = 0;
                        //cell.Borders.Left.Width = 0;
                        //cell.Borders.Right.Width = 0;
                        //availableRows = 30;
                        //availableRows -= 1;

                        CreateHeader();
                        availableRows = 30;
                        availableRows -= 1;

                        row = table.AddRow();
                        row.Borders.Width = 0;
                        cell = row.Cells[0];
                        cell.AddParagraph("Семестр" + fd[i].Semestr).Format.Alignment = ParagraphAlignment.Left;
                        cell.Borders.Width = 0;
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.MergeRight = 41;
                        availableRows -= 1;

                        row = table.AddRow();
                        row.Borders.Width = 0;
                        cell = row.Cells[0];
                        cell.AddParagraph("Дисципліна").Format.Alignment = ParagraphAlignment.Left;
                        cell.Borders.Width = 0;
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.MergeRight = 41;
                        availableRows -= 1;

                        for (int j = 0; j < fd[i].Teachers.Count; j++)
                        {
                            row = table.AddRow();
                            cell = row.Cells[0];
                            cell.AddParagraph(fd[i].Course.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[1];
                            cell.AddParagraph(fd[i].EduForm.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[2];
                            cell.AddParagraph(fd[i].FlowAndGroup.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[3];
                            cell.AddParagraph(fd[i].Teachers[j].ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[40];
                            cell.Borders.Left.Width = 1.5;
                            availableRows -= 1;
                        }

                        row = table.AddRow();
                        row.Borders.Width = 0;
                        cell = row.Cells[0];
                        cell.AddParagraph("Всього:").Format.Alignment = ParagraphAlignment.Left;
                        cell.Borders.Width = 0;
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.MergeRight = 41;
                        availableRows -= 1;

                        row = table.AddRow();
                        row.Shading.Color = Colors.LightSkyBlue;
                        cell = row.Cells[0];
                        cell.Format.Font.Bold = true;
                        cell.Format.Font.Color = Colors.Green;
                        cell.AddParagraph("").Format.Alignment = ParagraphAlignment.Left;
                        cell = row.Cells[40];
                        cell.Borders.Left.Width = 1.5;
                        availableRows -= 1;
                        
                    }

                }


            }
        }

        public override void CreateFooter()
        {
            if (availableRows > 0)
            {
                for (int i2 = 0; i2 < availableRows; i2++)
                {
                    row = table.AddRow();
                    //row.Shading.Color = Colors.Gray;    //look unused rows
                    row.Borders.Width = 0;
                    cell = row.Cells[0];
                    cell.MergeRight = 41;
                    cell.Borders.Width = 0;
                }
            }
            availableRows = 30;

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
            fd = fakeData.OrderBy(i => i.Semestr).ThenBy(i => i.Course).Where(i => i.Semestr == 1).ToList();
            CreateBody();
            fd = fakeData.OrderBy(i => i.Semestr).ThenBy(i => i.Course).Where(i => i.Semestr == 2).ToList();
            CreateFooter();
            CreateBody();
            section.Add(table);


            return document;
        }
    }
}
