using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angularzysko.Models;

namespace Angularzysko.Interfaces
{
    public interface IMyData
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(long id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(long id);
        void UpdateEmployee(long id, Employee employee);
    }
}
