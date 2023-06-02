using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OPDBillReportDTO
    {
        public DateTime OrderDate { get; set; }
        public double TotalBill { get; set; }
    }
}
