using MedicalSystem.Models;
using MedicalSystem.Models.Enums;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MedicalSystem.JsonToSql
{
    public class ReadPatient
    {
        private readonly Patient patient;
        private readonly string fileLocation;

        public ReadPatient(string fileLocation)
        {
            this.fileLocation = fileLocation;
            this.patient = ReadPatientFromFile();
        }

        private Patient ReadPatientFromFile()
        {
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string json = reader.ReadToEnd();
                var template = new
                {
                    Id = "",
                    Name = "",
                    Status = ""
                };
                var deserialized = JsonConvert.DeserializeAnonymousType(json, template);

                var patientToAdd = new Patient();
                patientToAdd.Name = deserialized.Name;
                patientToAdd.Id = int.Parse(deserialized.Id);

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
                return patientToAdd;
            }
        }

        public Patient Patient
        {
            get
            {
                return this.patient;
            }
        }
    }
}
