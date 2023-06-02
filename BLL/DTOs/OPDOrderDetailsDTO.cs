using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OPDOrderDetailsDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerOPDId { get; set; }
        public int ItemExamId { get; set; }
    }
}
