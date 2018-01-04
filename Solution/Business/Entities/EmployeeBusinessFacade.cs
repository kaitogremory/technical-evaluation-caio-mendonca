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
                    _IEmployeeDataAccess.Update(register);

                    if (register.DepedentList != null)
                    {
                        List<Dependent> dependentList = _dependentBusinessFacade.GetDependentList(register.Id).ToList();
                        List<int> dependentIdList = dependentList.Select(y => y.Id).ToList();

                        var listToInsert = register.DepedentList.Where(x => x.Id == 0).ToList();
                        var listToDelete = dependentIdList.Where(x => !register.DepedentList.Any(a => a.Id == x)).ToList();

                        foreach (var dep in listToInsert)
                        {
                            _dependentBusinessFacade.Insert(dep);
                        }

                        foreach (var IdDependent in listToDelete)
                        {
                            _dependentBusinessFacade.Delete(IdDependent);
                        }
                    }
                }
                else
                {                    
                    var idEmployee = _IEmployeeDataAccess.Insert(register);

                    if (register.DepedentList != null)
                    {
                        foreach (var dep in register.DepedentList)
                        {
                            dep.IdEmployee = idEmployee;
                            _dependentBusinessFacade.Insert(dep);
                        }
                    }
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
                _dependentBusinessFacade.DeleteByEmployee(idEmployee);
                _IEmployeeDataAccess.Delete(idEmployee);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
