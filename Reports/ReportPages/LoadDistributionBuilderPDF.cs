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


            List<TeacherInfo> teacherInfo = renderBody[8] as List<TeacherInfo>;
            List<TeacherLoad> teacherLoad = renderBody[9] as List<TeacherLoad>;
            List<Subject> subjectList = renderBody[5] as List<Subject>;
            List<Flow> flowList = renderBody[0] as List<Flow>;
            List<Group> groupList = renderBody[3] as List<Group>;
            List<TeacherLoadOtherType> tlOtherTypeList = renderBody[10] as List<TeacherLoadOtherType>;
            List<OtherType> otherTypeList = renderBody[11] as List<OtherType>;
            List<SubGroup> subGroupList = renderBody[4] as List<SubGroup>;
            double sumBudgetSemestrOne = 0;
            double sumContractSemestrOne = 0;

            switch (Discipline)
            {
                case "Лекції":
                    {
                        var query = teacherLoad.Where(w => w.LectionB > 0)
                            .Join(teacherInfo, tl => tl.TeacherInfo.Id, ti => ti.Id, (tl, ti) => new { _TeacherLoad = tl, _TeacherInfo = ti })
                            .Join(subjectList, prev => prev._TeacherLoad.Subject.Id, sl => sl.Id, (prev, ti) => new { _Teacher = prev, Subject = ti })
                            .Join(flowList, prev => prev.Subject.Id, fl => fl.Id, (prev, fl) => new { _TeachersAndSubjects = prev, _Flow = fl })
                            .ToList();

                        for (int i = 0; i < query.Count; i++)
                        {
                            row = table.AddRow();
                            row.VerticalAlignment = VerticalAlignment.Center;
                            cell = row.Cells[0];
                            cell.AddParagraph(query[i]._Flow.EduForm.ToString()).Format.Alignment = ParagraphAlignment.Center;

                            var queryCourse = groupList.Where(w => w.Flow.All(w2 => w2.Id == query[i]._Flow.Id)).FirstOrDefault();
                            cell = row.Cells[1];
                            cell.AddParagraph(queryCourse.Course.ToString()).Format.Alignment = ParagraphAlignment.Center;

                            cell = row.Cells[2];
                            cell.AddParagraph(query[i]._TeachersAndSubjects.Subject.Name).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[3];
                            cell.AddParagraph(query[i]._Flow.Name.Replace('|', ' ').ToString()).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[4];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherInfo.Initials).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[5];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            sumBudgetSemestrOne += query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursB;

                            cell = row.Cells[6];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            sumContractSemestrOne += query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursK;
                        }

                        break;
                    }

                case "Практичні заняття":
                    {
                        var query = teacherLoad.Where(w => w.PracticeB > 0)
                            .Join(teacherInfo, tl => tl.TeacherInfo.Id, ti => ti.Id, (tl, ti) => new { _TeacherLoad = tl, _TeacherInfo = ti })
                            .Join(subjectList, prev => prev._TeacherLoad.Subject.Id, sl => sl.Id, (prev, ti) => new { _Teacher = prev, Subject = ti })
                            .Join(flowList, prev => prev.Subject.Id, fl => fl.Id, (prev, fl) => new { _TeachersAndSubjects = prev, _Flow = fl })
                            .ToList();

                        for (int i = 0; i < query.Count; i++)
                        {
                            row = table.AddRow();
                            row.VerticalAlignment = VerticalAlignment.Center;
                            cell = row.Cells[0];
                            cell.AddParagraph(query[i]._Flow.EduForm.ToString()).Format.Alignment = ParagraphAlignment.Center;

                            var queryCourse = groupList.Where(w => w.Flow.All(w2 => w2.Id == query[i]._Flow.Id)).FirstOrDefault();
                            cell = row.Cells[1];
                            cell.AddParagraph(queryCourse.Course.ToString()).Format.Alignment = ParagraphAlignment.Center;

                            cell = row.Cells[2];
                            cell.AddParagraph(query[i]._TeachersAndSubjects.Subject.Name).Format.Alignment = ParagraphAlignment.Center;

                            var querySG = subGroupList.Where(w => w.Flow.Id == query[0]._Flow.Id).ToList();
                            cell = row.Cells[3];
                            cell.AddParagraph(querySG[i].Name.Replace('_', '-')).Format.Alignment = ParagraphAlignment.Center;

                            cell = row.Cells[4];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherInfo.Initials).Format.Alignment = ParagraphAlignment.Center;
                            cell = row.Cells[5];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            sumBudgetSemestrOne += query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursB;

                            cell = row.Cells[6];
                            cell.AddParagraph(query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                            sumContractSemestrOne += query[i]._TeachersAndSubjects._Teacher._TeacherLoad.TotalHoursK;

                        }
                        break;
                    }

                case "Лабораторні заняття":
                    {
                        break;
                    }

                case "Екзамени":
                    {
                        break;
                    }

                case "Розрахункові роботи":
                    {
                        break;
                    }

                case "Модульні роботи":
                    {
                        break;
                    }

                default:
                    break;
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
            cell = row.Cells[5];
            cell.AddParagraph(sumBudgetSemestrOne.ToString()).Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[6];
            cell.AddParagraph(sumContractSemestrOne.ToString()).Format.Alignment = ParagraphAlignment.Center;
            
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
