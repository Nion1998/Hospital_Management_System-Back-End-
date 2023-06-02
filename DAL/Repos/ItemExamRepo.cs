using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ItemExamRepo : Repo, IRepo<ItemExam, int, ItemExam>
    {
        public ItemExam Add(ItemExam obj)
        {
            db.ItemExams.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.ItemExams.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<ItemExam> Get()
        {
            return db.ItemExams.ToList();
        }

        public ItemExam Get(int id)
        {
            return db.ItemExams.Find(id);
        }

        public ItemExam Update(ItemExam obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
