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
        private DependentBusinessFacade _dependentBusinessFacade = new DependentBusinessFacade(new DependentDataAccess());        

        public EmployeeBusinessFacade(IEmployeeDataAccess EmployeeDataAccess)
        {
            _IEmployeeDataAccess = EmployeeDataAccess;
        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                var list = _IEmployeeDataAccess.GetEmployeeList();

                foreach (var emp in list)
                {
                    emp.DepedentList = _dependentBusinessFacade.GetDependentList(emp.Id);
                }

                return list;
            }
            
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Employee GetEmployeeById(int idEmployee)
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

        public void Save(Employee register)
        {
            try
            {
                if (register.Id > 0)
                {
                    //update
                    _IEmployeeDataAccess.Update(register);
                }
                else
                {
                    //insert
                    _IEmployeeDataAccess.Insert(register);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public void Delete(int idEmployee)
        {
            try
            {
                _IEmployeeDataAccess.Delete(idEmployee);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
