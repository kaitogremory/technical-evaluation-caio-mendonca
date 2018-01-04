using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEmployeeDataAccess
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeById(int idEmployee);
        void Save(Employee register);
        void Delete(int idEmployee);
    }
}
