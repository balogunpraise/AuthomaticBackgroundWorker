using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.Model;

namespace TaskScheduler.DataAccess
{
    public interface IEmployeeData
    {
        List<EmployeeModel> GetEmployeeList();
    }
}
