using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OTDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PatientId { get; set; }
        public string Details { get; set; }
        public string Surgeon { get; set; }
        public string Anesthetist { get; set; }
        public DateTime OTDate { get; set; }
        public int DoctorId { get; set; }
    }
}
