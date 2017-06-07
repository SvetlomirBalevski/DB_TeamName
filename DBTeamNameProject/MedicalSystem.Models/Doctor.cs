using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
            this.Diseases = new HashSet<Disease>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Hospital Hospital { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
