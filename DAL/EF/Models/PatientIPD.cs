using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PatientIPD
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string FatherName { get; set; }
        [StringLength(200)]
        [Required]
        public string MotherName { get; set; }
        [StringLength(250)]
        [Required]
        public string Address { get; set; }
        [StringLength(20)]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [StringLength(15)]
        [Required]
        public string Phone { get; set; }
        [StringLength(80)]
        public string Occupation { get; set; }
        public int? Nid { get; set; }
        public DateTime? AdmissionDate { get; set; }
        [StringLength(180)]
        public string RoomDetails { get; set; }
        [StringLength(180)]
        [Required]
        public string RefdBy { get; set; }
        [StringLength(180)]
        public string DutyDoctor { get; set; }
        [Required]
        public double PaidAmount { get; set; }


        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("Cabin")]
        public int? CabinId { get; set; }
        public virtual Cabin Cabin { get; set; }

    }
}
