using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
            this.Diseases = new HashSet<Disease>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public virtual Hospital Hospital { get; set; }

        [Required]
        [StringLength(30)]
        public virtual Specialty Specialty { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
