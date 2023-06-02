using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MaterialRepo : Repo, IRepo<Material, int, Material>
    {
        public Material Add(Material obj)
        {
            db.Materials.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Materials.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Material> Get()
        {
            return db.Materials.ToList();
        }

        public Material Get(int id)
        {
            return db.Materials.Find(id);
        }

        public Material Update(Material obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
