using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PharmacyBillingRepo : Repo, IRepo<PharmacyBilling, int, PharmacyBilling>
    {
        public PharmacyBilling Add(PharmacyBilling obj)
        {
            DateTime dy = DateTime.Now;
            obj.OrderDate = dy.Date;
            db.PharmacyBillings.Add(obj);

            if (db.SaveChanges() > 0) return obj;

            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.PharmacyBillings.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<PharmacyBilling> Get()
        {
            return db.PharmacyBillings.ToList();
        }

        public PharmacyBilling Get(int id)
        {
            return db.PharmacyBillings.Find(id);
        }

        public PharmacyBilling Update(PharmacyBilling obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
