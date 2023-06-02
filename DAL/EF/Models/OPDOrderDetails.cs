using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OPDOrderDetails
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }
        [Required]
        public int TotalPrice { get; set; }

        [ForeignKey("CustomerOPD")]
        public int CustomerOPDId { get; set; }

        [ForeignKey("ItemExam")]
        public int ItemExamId { get; set; }
        public virtual ItemExam ItemExam { get; set; }
        public virtual CustomerOPD CustomerOPD { get; set; }
    }
}
