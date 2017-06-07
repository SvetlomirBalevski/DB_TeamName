using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Hospital Hospital { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
