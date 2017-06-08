using MedicalSystem.Models.Enums;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Doctors = new HashSet<Doctor>();
            this.Diseases = new HashSet<Disease>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public PatientStatuses Status { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
