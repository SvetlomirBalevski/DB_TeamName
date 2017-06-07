using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Satus { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
