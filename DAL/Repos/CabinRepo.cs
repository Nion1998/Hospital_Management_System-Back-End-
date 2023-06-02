using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CabinRepo : Repo, IRepo<Cabin, int, Cabin>
    {
        public Cabin Add(Cabin obj)
        {
            db.Cabins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Cabins.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Cabin> Get()
        {
            return db.Cabins.ToList();
        }

        public Cabin Get(int id)
        {
            return db.Cabins.Find(id);
        }

        public Cabin Update(Cabin obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
