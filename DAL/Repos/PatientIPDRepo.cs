using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PatientIPDRepo : Repo, IRepo<PatientIPD, int, PatientIPD>
    {
        public PatientIPD Add(PatientIPD obj)
        {
            db.PatientIPDs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.PatientIPDs.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<PatientIPD> Get()
        {
            return db.PatientIPDs.ToList();
        }

        public PatientIPD Get(int id)
        {
            return db.PatientIPDs.Find(id);
        }

        public PatientIPD Update(PatientIPD obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
