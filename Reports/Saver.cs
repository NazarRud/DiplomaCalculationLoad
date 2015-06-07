using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Reports
{
    abstract class Saver
    {
        protected string fileName;
        public virtual void SaveDocument(object[] document) { }
        public virtual void SaveDocument(Document document) { }

        public void InitDirectoryStructure()
        {
            if(Directory.Exists(Environment.CurrentDirectory + @"\Звіти"))
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Звіти\Архів"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Архів");
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Архів\" + DateTime.Now.Year.ToString());
                }
                else
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + @"\Звіти\Архів\" + DateTime.Now.Year.ToString()))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Архів\" + DateTime.Now.Year.ToString());
                    }
                }
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Звіти\Поточні"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Поточні");
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Поточні\" + Enum.GetName(typeof(Monthes), DateTime.Now.Month) + " " + DateTime.Now.Year);
                }
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Звіти\Поточні\" + Enum.GetName(typeof(Monthes), DateTime.Now.Month) + " " + DateTime.Now.Year))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Поточні\" + Enum.GetName(typeof(Monthes), DateTime.Now.Month) + " " + DateTime.Now.Year);
                }
            }
            else
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти");
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Архів");
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Архів\" + DateTime.Now.Year.ToString());
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Поточні");
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Звіти\Поточні\" + Enum.GetName(typeof(Monthes), DateTime.Now.Month) + " " + DateTime.Now.Year);
            }
        }


    }
}
