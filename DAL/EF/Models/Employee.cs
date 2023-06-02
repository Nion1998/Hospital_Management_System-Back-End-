using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Employee
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
        [StringLength(50)]
        public string Role { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }

    }
}
