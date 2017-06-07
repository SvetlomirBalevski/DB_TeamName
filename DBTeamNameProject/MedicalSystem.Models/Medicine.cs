using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.Diseases = new HashSet<Disease>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string Description { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
