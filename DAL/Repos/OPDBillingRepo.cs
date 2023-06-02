using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OPDBillingRepo : Repo, IRepo<OPDBilling, int, OPDBilling>
    {
        public OPDBilling Add(OPDBilling obj)
        {
            DateTime dy = DateTime.Now;
            obj.OrderDate = dy.Date;
            db.OPDBillings.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.OPDBillings.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<OPDBilling> Get()
        {
            return db.OPDBillings.ToList();
        }

        public OPDBilling Get(int id)
        {
            return db.OPDBillings.Find(id);
        }

        public OPDBilling Update(OPDBilling obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}