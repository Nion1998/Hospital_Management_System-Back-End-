using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharmacyOrderDetailsDTO
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerPharmacyId { get; set; }
        public int MedicineId { get; set; }
    }
}
