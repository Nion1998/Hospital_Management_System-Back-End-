using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SupplierRepo : Repo, IRepo<Supplier, int, Supplier>
    {
        public Supplier Add(Supplier obj)
        {
            db.Suppliers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Suppliers.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Supplier> Get()
        {
            return db.Suppliers.ToList();
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public Supplier Update(Supplier obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
