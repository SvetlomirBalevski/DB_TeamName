using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Models.SQLiteModels
{
    public class Continent
    {
        public Continent()
        {
            // this.Diseases = new HashSet<Disease>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        // public virtual ICollection<Disease> Diseases { get; set; }
    }
}
