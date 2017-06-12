using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Specialty
    {
        public Specialty()
        {
            this.Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public override string ToString()
        {
            string doctors = this.Doctors.Count == 0 ?
                    $"No doctors with {this.Name} specialty"
                    : string.Join(" ", this.Doctors);

            return this.Id + " | " + this.Name + "\n\t" + doctors;
        }
    }
}
