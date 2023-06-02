using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OPDOrderDetailsRepo : Repo, IRepo<OPDOrderDetails, int, OPDOrderDetails>
    {
        public OPDOrderDetails Add(OPDOrderDetails obj)
        {
            db.OPDOrderDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.OPDOrderDetails.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<OPDOrderDetails> Get()
        {
            return db.OPDOrderDetails.ToList();
        }

        public OPDOrderDetails Get(int id)
        {
            return db.OPDOrderDetails.Find(id);
        }

        public OPDOrderDetails Update(OPDOrderDetails obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
