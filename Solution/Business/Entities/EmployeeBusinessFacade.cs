using Common.Entities;
using Common.Interfaces;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class EmployeeBusinessFacade
    {
        private IEmployeeDataAccess _IEmployeeDataAccess;

        public EmployeeBusinessFacade(IEmployeeDataAccess EmployeeDataAccess)
        {
            _IEmployeeDataAccess = EmployeeDataAccess;
        }

        public virtual List<Employee> GetEmployeeList()
        {
            try
            {
                var list = _IEmployeeDataAccess.GetEmployeeList();
                return list;
            }
            
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public virtual Employee GetEmployeeById(int idEmployee)
        {
            try
            {
                var register = _IEmployeeDataAccess.GetEmployeeById(idEmployee);
                return register;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
