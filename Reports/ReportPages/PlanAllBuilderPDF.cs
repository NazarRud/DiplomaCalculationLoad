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
using Reports.Public;
using Data.Entity;
using Data.Entity.Enum;

namespace Reports.ReportPages
{
    class PlanAllBuilderPDF : PDFPageBuilder
    {
        private string teacher;
        public PlanAllBuilderPDF(string teacher)
        {
            this.teacher = teacher;
        }
        public override void CreateHeader()
        {
            column = table.AddColumn(Unit.FromCentimeter(0.4));
            column = table.AddColumn(Unit.FromCentimeter(1.8));
            column = table.AddColumn(Unit.FromCentimeter(0.35));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            column = table.AddColumn(Unit.FromCentimeter(1.8));
            //column = table.AddColumn(Unit.FromCentimeter(0.9));

            for (int i = 0; i < 35; i++)
            {
                column = table.AddColumn(Unit.FromCentimeter(0.62));
            }

            column = table.AddColumn(Unit.FromCentimeter(0.655));
            column = table.AddColumn(Unit.FromCentimeter(0.8));
            column.Borders.Left.Width = 1.5;
            column = table.AddColumn(Unit.FromCentimeter(0.8));

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Top.Width = 0;
            row.Borders.Left.Width = 0;
            row.Borders.Right.Width = 0;
            cell = row.Cells[0];
            cell.AddParagraph(teacher).Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 20;
            cell.Borders.Right.Width = 0;
            cell = row.Cells[21];
            cell.AddParagraph(ReportsCreator.CurrentYear + " н.р.").Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 10;
            cell.Borders.Right.Width = 0;
            cell = row.Cells[32];
            cell.AddParagraph(DateTime.Now.ToString().Substring(0, 10)).Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Blue;
            cell.MergeRight = 9;

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
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Left.Width = 0;
            row.Borders.Right.Width = 0;
            cell = row.Cells[0];
            cell.AddParagraph("Семестр 1").Format.Alignment = ParagraphAlignment.Left;
            cell.MergeRight = 41;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Green;

            List<TeacherInfo> teacherInfo = renderBody[8] as List<TeacherInfo>;
            List<TeacherLoad> teacherLoad = renderBody[9] as List<TeacherLoad>;
            List<Subject> subjectList = renderBody[5] as List<Subject>;
            List<Flow> flowList = renderBody[0] as List<Flow>;
            List<Group> groupList = renderBody[3] as List<Group>;
            List<TeacherLoadOtherType> tlOtherTypeList = renderBody[10] as List<TeacherLoadOtherType>;
            List<OtherType> otherTypeList = renderBody[11] as List<OtherType>;

            var q = teacherInfo
                .Where(ti => ti.Initials == teacher)
                .Join(teacherLoad, ti => ti.Id, tl => tl.TeacherInfo.Id, (ti, tl) => new { _TeacherInfo = ti, _TeacherLoad = tl })
                .Join(subjectList, prev => prev._TeacherLoad.Subject.Id, sl => sl.Id, (prev, ti) => new { _Teacher = prev, Subject = ti })
                .Join(flowList, prev => prev.Subject.Id, fl => fl.Id, (prev, fl) => new { _TeachersAndSubjects = prev, _Flow = fl })                
                .Join(groupList, prev => prev._Flow.Id, gl => gl.Id, (prev, gl) => new { _FlowAndTeacherAndSubject = prev, _Group = gl })
                .OrderBy(ord => ord._Group.Course)
                .Where(w => w._FlowAndTeacherAndSubject._TeachersAndSubjects.Subject.Semestr == Semestr.I)
                //.Join(tlOtherTypeList, prev => prev._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherInfo.Id, tlot => tlot.Id, (prev, tlot) => new { _FlowAndTeacherAndSubjectAndGroup = prev, _TeacherLoadOtherType = tlot })
                //.Join(otherTypeList, prev => prev._TeacherLoadOtherType.Id, otl => otl.Id, (prev, otl) => new { _JoinedList = prev, _OtherType = otl})
                //.Where(w => w._OtherType.Semestr == Semestr.I) 
                    //&& w._OtherType.SubTypeWork ==  SubTypeWork.бакалаврів)//TypeWork.Керівництво_атестац_роб)
                .ToList();
            //q.Ea
                //ForEach(f => f._OtherType.Semestr == Semestr.I && f._OtherType.TypeWork == TypeWork.Керівництво_атестац_роб);

            for (int i = 0; i < q.Count; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                /// Entering data semestr 1
                //cell = row.Cells[0];
                //cell.AddParagraph((i + 1).ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[1];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects.Subject.Name).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[2];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._Group.Course.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[3];
                //cell.AddParagraph(Enum.GetName(typeof(EducationForm), q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._Flow.EduForm)).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[4];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._Flow.Name).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[5];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._Flow.AllCountBudget.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[6];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._Flow.AllCountContract.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[7];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.LectionB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[8];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.LectionK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[9];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.PracticeB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[10];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.PracticeK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[11];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.LabB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[12];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.LabK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[13];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.ExamB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[14];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.ExamK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[15];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CreditB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[16];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CreditK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[17];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.TestB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[18];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.TestK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[19];
                //cell.AddParagraph((q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CourseProjectB + q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CourseWorkB).ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[20];
                //cell.AddParagraph((q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CourseProjectK + q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.CourseWorkK).ToString()).Format.Alignment = ParagraphAlignment.Center;

                //cell = row.Cells[21];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.RgrB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[22];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.RgrK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[23];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.DkrB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[24];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.DkrK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[25];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.СonsultationB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[26];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.СonsultationK.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[27];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.PracticeB.ToString()).Format.Alignment = ParagraphAlignment.Center;
                //cell = row.Cells[28];
                //cell.AddParagraph(q[i]._JoinedList._FlowAndTeacherAndSubjectAndGroup._FlowAndTeacherAndSubject._TeachersAndSubjects._Teacher._TeacherLoad.PracticeK.ToString()).Format.Alignment = ParagraphAlignment.Center;

                //string a = null;
                //if (q[i]._OtherType.SubTypeWork == SubTypeWork.бакалаврів)
                //{
                //    a = q[i]._JoinedList._TeacherLoadOtherType.CountHoursB.ToString();
                //}


                cell = row.Cells[29];
                cell.AddParagraph(
                    //q[i]._JoinedList._TeacherLoadOtherType.CountHoursB.ToString()
                    //a
                    //q[i]._OtherType.SubTypeWork == SubTypeWork.бакалаврів ? q[i]._JoinedList._TeacherLoadOtherType.CountHoursB.ToString() : ""
                    ).Format.Alignment = ParagraphAlignment.Center;
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.LightGray;
            cell = row.Cells[0];
            cell.AddParagraph("Разом за семестр 1").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 4;
            cell.Format.Font.Bold = true;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Borders.Left.Width = 0;
            row.Borders.Right.Width = 0;
            cell = row.Cells[0];
            cell.AddParagraph("Семестр 2").Format.Alignment = ParagraphAlignment.Left;
            cell.MergeRight = 41;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Color = Colors.Green;

            for (int i = 0; i < 11; i++)
            {
                row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;
                /// Entering data semestr 2
            }

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.LightGray;
            cell = row.Cells[0];
            cell.AddParagraph("Разом за семестр 2").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 4;
            cell.Format.Font.Bold = true;

        }

        public override void CreateRightSideBody()
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cell = column[i].Row[40];
                //cell.Borders.Left.Width = 1.5;
            }
        }

        public override void CreateFooter()
        {
            row = table.AddRow();
            cell = row.Cells[0];
            cell.MergeRight = 41;
            row.Borders.Left.Width = 0;
            row.Borders.Right.Width = 0;
            
            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Colors.Yellow;
            cell = row.Cells[0];
            cell.AddParagraph("Всього:").Format.Alignment = ParagraphAlignment.Center;
            cell.MergeRight = 4;
            cell.Format.Font.Bold = true;
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

            CreateHeader();
            CreateBody();
            CreateFooter();
            CreateRightSideBody();
            section.Add(table);


            return document;
        }
    }
}
