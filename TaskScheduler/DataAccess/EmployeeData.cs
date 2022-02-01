using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.Model;

namespace TaskScheduler.DataAccess
{
    public class EmployeeData : IEmployeeData
    {
        readonly List<EmployeeModel> employee = new();

        public EmployeeData()
        {
            employee.Add(new EmployeeModel { Id = 1, FirstName = "John", LastName = "Yu", Salary = 30000 });
            employee.Add(new EmployeeModel { Id = 2, FirstName = "Stephen", LastName = "Stone", Salary = 45000 });
            employee.Add(new EmployeeModel { Id = 3, FirstName = "Nicky", LastName = "James", Salary = 50000 });
            employee.Add(new EmployeeModel { Id = 4, FirstName = "Ann", LastName = "Berry", Salary = 40000 });
            employee.Add(new EmployeeModel { Id = 5, FirstName = "Mike", LastName = "Johnson", Salary = 30000 });
            employee.Add(new EmployeeModel { Id = 6, FirstName = "James", LastName = "Mark", Salary = 20000 });
        }



        public List<EmployeeModel> GetEmployeeList()
        {
            return employee;
        }
    }
}
