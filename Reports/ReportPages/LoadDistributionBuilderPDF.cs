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
using Reports.Public;
using Data.Entity;
using Data.Entity.Enum;

namespace Reports.ReportPages
{
    class LoadDistributionBuilderPDF : PDFPageBuilder
    {
        public string Discipline { get; private set; }
        private LoadDistributionBuilderPDF()
        {
        }

        public LoadDistributionBuilderPDF(string discipline)
        {
            Discipline = discipline;
        }
        public override void CreateHeader()
        {
            table.Borders.Width = 0.2;

            column = table.AddColumn(Unit.FromCentimeter(1.5));
            column = table.AddColumn(Unit.FromCentimeter(0.9));
            column = table.AddColumn(Unit.FromCentimeter(8.0));
            column = table.AddColumn(Unit.FromCentimeter(4.0));
            column = table.AddColumn(Unit.FromCentimeter(2.5));
            column = table.AddColumn(Unit.FromCentimeter(1.5));
            column = table.AddColumn(Unit.FromCentimeter(1.5));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Width = 0;
            cell = row.Cells[0];
            cell.AddParagraph("Кафедра АСОІУ").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 2;
            cell = row.Cells[3];
            cell.AddParagraph(ReportsCreator.CurrentYear + " навчальний рік").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 3;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Width = 0;
            //row.Format.Borders.Bottom.Style = BorderStyle.Single;
            row.Format.Font.Color = Colors.Blue;
            row.Borders.Bottom.Width = 0.7;
            row.Borders.Bottom.Color = Colors.Blue;
            cell = row.Cells[0];
            cell.AddParagraph(Discipline).Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 6;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.LightBlue;
            row.Format.Font.Color = Colors.Blue;
            cell = row.Cells[0];
            cell.AddParagraph("Форма навч.").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeDown = 1;
            cell = row.Cells[1];
            cell.AddParagraph("Курс").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeDown = 1;
            cell = row.Cells[2];
            cell.AddParagraph("Дисципліна").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeDown = 1;
            cell = row.Cells[3];
            cell.AddParagraph("Потік/Група").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeDown = 1;
            cell = row.Cells[4];
            cell.AddParagraph("Викладач").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeDown = 1;
            cell = row.Cells[5];
            cell.AddParagraph("Години").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.LightBlue;
            row.Format.Font.Color = Colors.Blue;
            cell = row.Cells[5];
            cell.AddParagraph("Б").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell = row.Cells[6];
            cell.AddParagraph("К").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            

        }

        public override void CreateBody()
        {
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.BottomPadding = 4;
            row.TopPadding = 4;
            row.Borders.Top.Width = 0.7;
            row.Borders.Top.Color = Colors.Blue;
            row.Format.Font.Color = Colors.Blue;
            row.Borders.Left.Width = 0;   /////////////////////
            row.Borders.Right.Width = 0;   //////////////////////
            cell = row.Cells[0];
            cell.AddParagraph("Семестр     1").Format.Alignment = ParagraphAlignment.Left;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 6;
            #region reg
            //List<Subject> subjectList = renderBody[4] as List<Subject>;
            //var q = subjectList.Select(sl =>
            //    new { Name = sl.Name, 
            //        EduForm = sl.Flow.EduForm, 
            //        Flow = sl.Flow.Name,
            //        Semestr = sl.Semestr,
            //        Group = sl.Flow.Group.Select(gr => 
            //            new { Course = gr.Course,
            //                  Cathedra = gr.Cathedra.TeacherInfo.Select(ti => 
            //                      new { LastName = ti.LastName, 
            //                          Name = ti.Name, 
            //                          MiddleName = ti.MiddleName,
            //                          TeacherLoadOtherType = ti.TeacherLoadOtherType.Select(tlot => 
            //                              new { TypeOfWork = tlot.OtherType}),
            //                            TeachersLoad = ti.TeacherLoad.Select(tl => 
            //                                new { LectionB = tl.LectionB,
            //                                    LectionK = tl.LectionK                                                
            //                                })
            //                      })
            //            })

            //    }).Where(item => Enum.GetName(typeof(Semestr), item.Semestr) == Enum.GetName(typeof(Semestr), Semestr.I)).ToList();
            ////var q2 = q.Where(item => item.Group.)

            for (int i = 0; i < 19; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                //cell = row.Cells[0];
                //cell.AddParagraph(q[i].EduForm.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[2];
                //cell.AddParagraph(q[i].Name.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[3];
                //cell.AddParagraph(q[i].Flow.ToString()).Format.Alignment = ParagraphAlignment.Center;

            }
            #endregion
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Left.Width = 0;   /////////////////////
            //row.Borders.Right.Width = 0;   //////////////////////
            row.Borders.Bottom.Width = 1.5;   /////////////////////
            cell = row.Cells[0];
            cell.AddParagraph("Всього за 1 семестр").Format.Alignment = ParagraphAlignment.Left;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 4;
            
        }

        public override void CreateAdditionalElement()
        {
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.BottomPadding = 4;
            row.TopPadding = 4;
            row.Borders.Left.Width = 0;   /////////////////////
            row.Borders.Right.Width = 0;   //////////////////////
            cell = row.Cells[0];
            cell.AddParagraph("Семестр     2").Format.Alignment = ParagraphAlignment.Left;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 6;

            for (int i = 0; i < 19; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Left.Width = 0;   /////////////////////
            //row.Borders.Right.Width = 0;   //////////////////////
            row.Borders.Bottom.Width = 1.5;   /////////////////////
            cell = row.Cells[0];
            cell.AddParagraph("Всього за 2 семестр").Format.Alignment = ParagraphAlignment.Left;
            cell.Format.Font.Bold = true;
            cell.MergeRight = 4;
        }

        public override void CreateFooter()
        {
            row = table.AddRow();
            row.Borders.Width = 0;

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Всього:").Format.Alignment = ParagraphAlignment.Right;
            cell.MergeRight = 4;
            cell.Borders.Bottom.Width = 0;
            cell.Borders.Left.Width = 0;
            cell.Borders.Top.Width = 0;
            cell.Format.Font.Bold = true;

            cell = row.Cells[5];
            cell.Shading.Color = Colors.LightGray;
            cell = row.Cells[6];
            cell.Shading.Color = Colors.LightGray;
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
            CreateAdditionalElement();
            CreateFooter();
            section.Add(table);


            return document;
        }
    }
}
