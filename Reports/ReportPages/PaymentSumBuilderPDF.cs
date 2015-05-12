﻿using System;
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
    public class PaymentSumBuilderPDF : PDFPageBuilder
    {
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(1.0));

            column = table.AddColumn(Unit.FromCentimeter(4.4));

            for (int i = 0; i < 7; i++)
            {
                column = table.AddColumn(Unit.FromCentimeter(2.1));
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Width = 0;
            cell = row.Cells[0];
            cell.AddParagraph("Сума виплат викладачам за контрактну форму навчання").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 8;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Wheat;
            cell = row.Cells[0];
            cell.AddParagraph("№").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[1];
            cell.AddParagraph("Прізвище І.Б.").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[2];
            cell.AddParagraph("Оклад").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[3];
            cell.AddParagraph("Надбання за вислугу років").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[4];
            cell.AddParagraph("Надбання за вчене звання").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[5];
            cell.AddParagraph("Надбання за науковий ступінь").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[6];
            cell.AddParagraph("Частка окладу за контрактом").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[7];
            cell.AddParagraph("Коефіцієнт зниження").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[8];
            cell.AddParagraph("Сума за місяць(грн.)").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;

        }

        public override void CreateBody()
        {
            for (int i = 0; i < 40; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
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
            CreateBody();
            section.Add(table);

            return document;
        }
    }
}
