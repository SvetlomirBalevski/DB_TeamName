using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.Diseases = new HashSet<Disease>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
