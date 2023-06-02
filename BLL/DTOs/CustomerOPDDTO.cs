using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerOPDDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Phone { get; set; }
        public string RefdBy { get; set; }
        public string Remark { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }

        public int? DoctorId { get; set; }
    }
}
