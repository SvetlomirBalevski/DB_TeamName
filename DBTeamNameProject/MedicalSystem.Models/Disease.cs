using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Disease
    {
        public Disease()
        {
            this.Patients = new HashSet<Patient>();
            this.Doctors = new HashSet<Doctor>();
            this.Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
