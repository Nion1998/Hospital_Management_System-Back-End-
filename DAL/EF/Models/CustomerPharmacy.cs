using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CustomerPharmacy
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

        public CustomerPharmacy()
        {
            PharmacyBillings = new List<PharmacyBilling>();
            PharmacyOrderDetails = new List<PharmacyOrderDetails>();
        }
        public virtual List<PharmacyBilling> PharmacyBillings { get; set; }
        public virtual List<PharmacyOrderDetails> PharmacyOrderDetails { get; set; }

    }
}
