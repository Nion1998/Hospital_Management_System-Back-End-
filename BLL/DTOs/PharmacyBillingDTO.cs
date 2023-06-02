using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharmacyBillingDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double ItemTotal { get; set; }
        public double Discount { get; set; }
        public double TotalBill { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }

        public int CustomerPharmacyId { get; set; }
    }
}
