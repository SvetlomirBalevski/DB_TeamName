using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
