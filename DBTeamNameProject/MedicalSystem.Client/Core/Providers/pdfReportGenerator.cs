using MedicalSystem.Client.Core.Contracts;
using MedicalSystem.pdfReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Client.Core.Providers
{
    class pdfReportGenerator : iReportGenerator
    {
        public void GeneratePdf(string message)
        {
            var pdfReport = new Generator();
            pdfReport.Generate(message);
        }
    }
}
