using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PharmacyOrderDetailsRepo : Repo, IRepo<PharmacyOrderDetails, int, PharmacyOrderDetails>
    {
        public PharmacyOrderDetails Add(PharmacyOrderDetails obj)
        {
            db.PharmacyOrderDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.PharmacyOrderDetails.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<PharmacyOrderDetails> Get()
        {
            return db.PharmacyOrderDetails.ToList();
        }

        public PharmacyOrderDetails Get(int id)
        {
            return db.PharmacyOrderDetails.Find(id);
        }

        public PharmacyOrderDetails Update(PharmacyOrderDetails obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
