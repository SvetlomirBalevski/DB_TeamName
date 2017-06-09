using MedicalSystem.Data;
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
            var readedPatient = new ReadPatient("../../../JSON Examples/PatientJSON.json");

            AddToSql.Patient(readedPatient.Patient);

            Console.WriteLine("Patient Added");

            var readedDisease = new ReadDisease("../../../JSON Examples/DiseaseJSON.json");

            AddToSql.Disease(readedDisease.Disease);

            Console.WriteLine("Disease added");
        }
    }
}
