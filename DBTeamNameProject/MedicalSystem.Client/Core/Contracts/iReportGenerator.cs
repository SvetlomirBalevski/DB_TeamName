using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Client.Core.Contracts
{
    public interface iReportGenerator
    {
        void GeneratePdf(string message);
    }
}
