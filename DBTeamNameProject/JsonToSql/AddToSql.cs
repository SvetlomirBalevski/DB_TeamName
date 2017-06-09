using MedicalSystem.Data;
using MedicalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.JsonToSql
{
  static class AddToSql
    {
       public static void Patient(Patient patient)
        {
            //create DBContext object
            using (var dbContext = new MedicalSystemDbContext())
            {
                //Add Student object into Students DBset
                dbContext.Patients.Add(patient);

                // call SaveChanges method to save student into database
                dbContext.SaveChanges();
            }
        }

        public static void Disease(Disease disease)
        {
            using (var dbContext = new MedicalSystemDbContext())
            {
                //Add Student object into Students DBset
                dbContext.Diseases.Add(disease);

                // call SaveChanges method to save student into database
                dbContext.SaveChanges();
            }
        }
    }
}
