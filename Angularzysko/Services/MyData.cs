using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Angularzysko.Interfaces;
using Angularzysko.Models;

namespace Angularzysko.Services
{
    public class MyData : IMyData
    {
        private readonly EmployeeContext _db;

        public MyData(EmployeeContext db)
        { _db = db; }

        public List<Employee> GetEmployees()
        {
            return _db.Employee.ToList();
        }

        public Employee GetEmployee(long id)
        { return _db.Employee.FirstOrDefault(t => t.ID == id); }

        public void AddEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(long id)
        {
            _db.Employee.Remove(_db.Employee.FirstOrDefault(t => t.ID == id));
            _db.SaveChanges();
        }

        public void UpdateEmployee(long id, Employee employee)
        {
            var tmp = _db.Employee.FirstOrDefault(t => t.ID == id);
            tmp.Name = employee.Name;
            tmp.Surname = employee.Surname;
            tmp.Telephone = employee.Telephone;
            tmp.Address = employee.Address;
            _db.SaveChanges();
        }
    }
}
