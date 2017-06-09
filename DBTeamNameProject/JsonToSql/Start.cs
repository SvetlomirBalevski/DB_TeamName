using MedicalSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToSql
{
    class Start
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../../JSON Examples/PatientJSON.json"))
            {
                string json = reader.ReadToEnd();
                List<Patient> Patient = JsonConvert.DeserializeObject<List<Patient>>(json);
            }

            Console.WriteLine("Patient");
        }
    }
}
