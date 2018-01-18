using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angularzysko.Models;
using Angularzysko.Data;

namespace Angularzysko.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();


            if (context.Employee.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
            new Employee{Name="Monika",Surname="Mazur",Telephone="668695989",Address="ul. Reja 19/18"},
            new Employee{Name="John",Surname="Smith",Telephone="4155552671",Address="123 Green Avenue"},
            new Employee{Name="Harpa",Surname="Hilmarsson",Telephone="3548888",Address="ul. Reja 19/18"}
            };
            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();


        }
    }


}