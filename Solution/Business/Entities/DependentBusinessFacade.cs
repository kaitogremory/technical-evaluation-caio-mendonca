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
    public class DependentBusinessFacade
    {
        private IDependentDataAccess _IDependentDataAccess;

        public DependentBusinessFacade(IDependentDataAccess DependentDataAccess)
        {
            _IDependentDataAccess = DependentDataAccess;
        }

        public List<Dependent> GetDependentList(int idEmployee)
        {
            try
            {
                var list = _IDependentDataAccess.GetDependentList(idEmployee);
                return list;
            }
            
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void Insert(Dependent dep)
        {
            try
            {
                _IDependentDataAccess.Insert(dep);                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idDependent)
        {
            try
            {
                _IDependentDataAccess.Delete(idDependent);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteByEmployee(int idEmployee)
        {
            try
            {
                _IDependentDataAccess.DeleteByEmployee(idEmployee);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
