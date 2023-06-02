using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentInfoDTO
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public double Amount { get; set; }
    }
}
