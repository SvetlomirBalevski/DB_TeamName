using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.pdfReports
{
    public class Generator
    {
        private readonly iTextSharp.text.Document document;
        private readonly string pathToFile = "../../../Reports/Report.pdf";

        public Generator()
        {
            this.document = new Document(PageSize.A4, 50, 50, 25, 25);
        }
        public void Generate(string query)
        {
            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(pathToFile, FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            var paragraf = new Paragraph(query);
            document.Add(paragraf);

            // Close the Document - this saves the document contents to the output stream
            document.Close();
        }
    }
}
