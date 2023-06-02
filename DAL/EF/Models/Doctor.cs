using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [StringLength(15)]
        [Required]
        public string Phone { get; set; }
        [Required]
        [StringLength(300)]
        public string Qualification { get; set; }
        [StringLength(300)]
        [Required]
        public string Specialization { get; set; }

        public Doctor()
        {
            PatientIPDs = new List<PatientIPD>();
            CustomerOPDs = new List<CustomerOPD>();
            OTDetails = new List<OTDetails>();
        }
        public virtual List<PatientIPD> PatientIPDs { get; set; }
        public virtual List<CustomerOPD> CustomerOPDs { get; set; }
        public virtual List<OTDetails> OTDetails { get; set; }


    }


}
