using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OPDBilling
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public double ItemTotal { get; set; }
        public double? Discount { get; set; }
        [Required]
        public double TotalBill { get; set; }
        [Required]
        public double PaidAmount { get; set; }
        [Required]
        public double DueAmount { get; set; }

        [ForeignKey("CustomerOPD")]
        public int CustomerOPDId { get; set; }
        public virtual CustomerOPD CustomerOPD { get; set; }
    }
}
