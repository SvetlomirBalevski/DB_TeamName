using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
