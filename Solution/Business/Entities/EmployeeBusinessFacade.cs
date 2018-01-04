using Business.Base;
using Common.Entities;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class EmployeeBusinessFacade : BaseConnectedBusinessFacade<IEmployeeDataAccess>
    {
        public virtual List<Employee> GetEmployeeList()
        {
            try
            {
                var list = dataAccess.GetEmployeeList();
                return list;
            }
            
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
