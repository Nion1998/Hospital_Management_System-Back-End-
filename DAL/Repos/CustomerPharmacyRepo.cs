using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerPharmacyRepo : Repo, IRepo<CustomerPharmacy, int, CustomerPharmacy>
    {
        public CustomerPharmacy Add(CustomerPharmacy obj)
        {
            db.CustomerPharmacies.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.CustomerPharmacies.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<CustomerPharmacy> Get()
        {
            return db.CustomerPharmacies.ToList();
        }

        public CustomerPharmacy Get(int id)
        {
            return db.CustomerPharmacies.Find(id);
        }

        public CustomerPharmacy Update(CustomerPharmacy obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
