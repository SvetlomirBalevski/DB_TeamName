using MedicalSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.JsonToSql
{
    class Start
    {
        static void Main()
        {
            var add = new AddPatient("../../../JSON Examples/PatientJSON.json");   
        }
    }
}
