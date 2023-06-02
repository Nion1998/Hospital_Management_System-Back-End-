using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, Employee>, IAuth
    {
        public Employee Add(Employee obj)
        {
            db.Employees.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Authenticate(string uname, string pass)
        {
            var data = db.Employees.FirstOrDefault(u => u.Username.Equals(uname) && u.Password.Equals(pass));
            if (data != null) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Employees.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Update(Employee obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
