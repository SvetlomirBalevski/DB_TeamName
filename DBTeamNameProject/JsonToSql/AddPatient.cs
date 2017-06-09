using MedicalSystem.Models;
using MedicalSystem.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.JsonToSql
{
    public class AddPatient : DbContext
    {
        private readonly Patient patient;
        private readonly string fileLocation;

        public AddPatient(string fileLocation)
        {
            this.fileLocation = fileLocation;
            this.patient = ReadPatientFromFile();
            AddPatientToSql(patient);
        }

        private Patient ReadPatientFromFile()
        {
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string json = reader.ReadToEnd();
                var template = new
                {
                    Name = "",
                    Status = ""
                };
                var deserialized = JsonConvert.DeserializeAnonymousType(json, template);

                var patientToAdd = new Patient();
                patientToAdd.Name = deserialized.Name;

                //patientToAdd.Status = Enum.GetNames(typeof(PatientStatuses)).Any(f => f.Equals(deserialized.Status));

                string[] enumValues = new string[] { "Healthy","Ill",
        "GettingBetter","GettingWorse","Dead","Simulant","Zombie","Newcommer"};
                bool isStatusCorrect = false;

                for (int i = 0; i < enumValues.Length; i++)
                {
                    if ((deserialized.Status == enumValues[i]))
                    {
                        patientToAdd.Status = (PatientStatuses)Enum.Parse(typeof(PatientStatuses), enumValues[i]);
                        isStatusCorrect = true;
                        break;
                    }
                }

                if (!isStatusCorrect || patientToAdd.Name == null)
                {
                    throw new ArgumentException("IncorrectPatient");
                }
                Console.WriteLine("PatientAdded");

                return patientToAdd;
            }
        }

        private void AddPatientToSql(Patient patientToAdd)
        {
            //using (var context = new DbContext())
            //{

            //}
        }
    }
}
