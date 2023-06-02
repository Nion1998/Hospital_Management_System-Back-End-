using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MedicineRepo : Repo, IRepo<Medicine, int, Medicine>
    {
        public Medicine Add(Medicine obj)
        {
            db.Medicines.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Medicines.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Medicine> Get()
        {
            return db.Medicines.ToList();
        }

        public Medicine Get(int id)
        {
            return db.Medicines.Find(id);
        }

        public Medicine Update(Medicine obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
