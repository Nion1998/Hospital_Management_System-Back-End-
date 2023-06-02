using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Cabin
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(30)]
        public string Status { get; set; }
        [Required]
        public double Rent { get; set; }

        public Cabin()
        {
            PatientIPDs = new List<PatientIPD>();
        }
        public virtual List<PatientIPD> PatientIPDs { get; set; }
    }
}
