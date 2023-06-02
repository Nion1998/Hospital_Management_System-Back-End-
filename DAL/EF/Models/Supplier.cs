using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Supplier
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public Supplier()
        {
            Medicines = new List<Medicine>();
        }
        public virtual List<Medicine> Medicines { get; set; }
    }
}
