using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public Medicine()
        {
            PharmacyOrderDetails = new List<PharmacyOrderDetails>();
        }
        public virtual List<PharmacyOrderDetails> PharmacyOrderDetails { get; set; }
    }
}
