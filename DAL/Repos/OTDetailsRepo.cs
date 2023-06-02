using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OTDetailsRepo : Repo, IRepo<OTDetails, int, OTDetails>
    {
        public OTDetails Add(OTDetails obj)
        {
            db.OTDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.OTDetails.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<OTDetails> Get()
        {
            return db.OTDetails.ToList();
        }

        public OTDetails Get(int id)
        {
            return db.OTDetails.Find(id);
        }

        public OTDetails Update(OTDetails obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
