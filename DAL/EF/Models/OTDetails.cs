using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OTDetails
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string PatientId { get; set; }
        [StringLength(200)]
        [Required]
        public string Details { get; set; }
        [StringLength(250)]
        [Required]
        public string Surgeon { get; set; }
        [Required]
        public string Anesthetist { get; set; }
        [Required]
        public DateTime OTDate { get; set; }     

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

}
