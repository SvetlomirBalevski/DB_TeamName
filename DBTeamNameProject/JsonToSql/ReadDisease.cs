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
    public class ReadDisease
    {
        private readonly Disease disease;
        private readonly string fileLocation;

        public ReadDisease(string fileLocation)
        {
            this.fileLocation = fileLocation;
            this.disease = ReadDiseseFromFile();
        }

        private Disease ReadDiseseFromFile()
        {
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string json = reader.ReadToEnd();
                var template = new
                {
                    Id = "",
                    Name = "",
                    Description = ""
                };
                var deserialized = JsonConvert.DeserializeAnonymousType(json, template);

                var diseaseToAdd = new Disease();
                diseaseToAdd.Name = deserialized.Name;
                diseaseToAdd.Id = int.Parse(deserialized.Id);
                diseaseToAdd.Description = deserialized.Description;

                if (diseaseToAdd.Id <= 0 || diseaseToAdd.Name == null)
                {
                    throw new ArgumentException("Incorrect Disease");
                }
                return diseaseToAdd;
            }
        }

        public Disease Disease
        {
            get
            {
                return this.disease;
            }
        }
    }
}
