using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerOPDRepo : Repo, IRepo<CustomerOPD, int, CustomerOPD>
    {
        public CustomerOPD Add(CustomerOPD obj)
        {
            db.CustomerOPDs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.CustomerOPDs.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<CustomerOPD> Get()
        {
            return db.CustomerOPDs.ToList();
        }

        public CustomerOPD Get(int id)
        {
            return db.CustomerOPDs.Find(id);
        }

        public CustomerOPD Update(CustomerOPD obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
