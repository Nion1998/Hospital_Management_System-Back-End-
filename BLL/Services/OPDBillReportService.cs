using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OPDBillReportService
    {
        public static List<OPDBillReportDTO> Get()
        {
            var db = PharmacyBillingService.Get();
            var lis = new List<OPDBillReportDTO>();
            DateTime enddate = DateTime.Now;
            for (DateTime startdate = DateTime.Now.AddMonths(-1); startdate.Date <= enddate.Date; startdate = startdate.AddDays(1))
            {

                var li = new List<PharmacyBillingDTO>();
                foreach (var item in db)
                {
                    if (DateTime.Equals(startdate.Date, item.OrderDate)) { li.Add(item); }

                }
                double su = 0;
                if (li.Count > 0)
                {
                    su = li.Sum(y => y.TotalBill);
                }



                lis.Add(new OPDBillReportDTO() { OrderDate = startdate, TotalBill = su });


            }
            var s = lis;
            return lis;

        }
    }
}
