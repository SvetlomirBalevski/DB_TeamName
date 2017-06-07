using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Models
{
    public class Hospital
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
