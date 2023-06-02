using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CabinDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public double Rent { get; set; }
    }
}
