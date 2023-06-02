using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PatientIPDDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int Nid { get; set; }
        public string Occupation { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string RoomDetails { get; set; }
        public string RefdBy { get; set; }
        public string DutyDoctor { get; set; }
        public double PaidAmount { get; set; }
        public string PaymentStatus { get; set; }

        public int CabinId { get; set; }
        public int DoctorId { get; set; }
    }
}
