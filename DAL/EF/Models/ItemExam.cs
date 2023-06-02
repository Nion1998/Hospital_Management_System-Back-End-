using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ItemExam
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public double Rate { get; set; }

        public ItemExam()
        {
            OPDOrderDetails = new List<OPDOrderDetails>();
        }
        public virtual List<OPDOrderDetails> OPDOrderDetails { get; set; }
    }
}
