using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OpenXmlDocument
    {

        public OpenXmlDocument()
        {
        }

        public void CreerFacture()
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create("C:\\test\\test11.docx", DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();

                // Crée la structure du document
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());

                // le contenu du document
                run.AppendChild(new Text("Nouveau document Word"));
            }
        }

    }
}
