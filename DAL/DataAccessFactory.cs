using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DataAccessFactory
    {
        public static IRepo<PatientIPD,int,PatientIPD> PatientIPDDataAccess()
        {
            return new PatientIPDRepo();
        }
        public static IRepo<Cabin,int,Cabin> CabinDataAccess()
        {
            return new CabinRepo();
        }
        public static IRepo<Doctor, int, Doctor> DoctorDataAccess()
        {
            return new DoctorRepo();
        }
        public static IRepo<CustomerOPD, int, CustomerOPD> CustomerOPDDataAccess()
        {
            return new CustomerOPDRepo();
        }
        public static IRepo<OTDetails, int, OTDetails> OTDetailsDataAccess()
        {
            return new OTDetailsRepo();
        }
        public static IRepo<Employee, int, Employee> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<ItemExam, int, ItemExam> ItemExamDataAccess()
        {
            return new ItemExamRepo();
        }
        public static IRepo<Material, int, Material> MaterialDataAccess()
        {
            return new MaterialRepo();
        }
        public static IRepo<OPDBilling, int, OPDBilling> OPDBillingDataAccess()
        {
            return new OPDBillingRepo();
        }
        public static IRepo<OPDOrderDetails, int, OPDOrderDetails> OPDOrderDetailsDataAccess()
        {
            return new OPDOrderDetailsRepo();
        }
        public static IRepo<CustomerPharmacy, int, CustomerPharmacy> CustomerPharmacyDataAccess()
        {
            return new CustomerPharmacyRepo();
        }
        public static IRepo<Medicine, int, Medicine> MedicineDataAccess()
        {
            return new MedicineRepo();
        }
        public static IRepo<Supplier, int, Supplier> SupplierDataAccess()
        {
            return new SupplierRepo();
        }
        public static IRepo<PharmacyBilling, int, PharmacyBilling> PharmacyBillingDataAccess()
        {
            return new PharmacyBillingRepo();
        }
        public static IRepo<PharmacyOrderDetails, int, PharmacyOrderDetails> PharmacyOrderDetailsDataAccess()
        {
            return new PharmacyOrderDetailsRepo();
        }


        public static IAuth AuthDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }

    }
}
