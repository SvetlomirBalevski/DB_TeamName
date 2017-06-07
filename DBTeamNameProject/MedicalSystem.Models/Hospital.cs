using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Models
{
    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new HashSet<Doctor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
