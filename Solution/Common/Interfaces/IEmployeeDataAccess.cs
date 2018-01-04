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
        int Insert(Employee register);
        void Update(Employee register);
        void Delete(int idEmployee);
    }
}
