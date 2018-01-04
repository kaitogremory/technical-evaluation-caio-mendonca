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

        public virtual List<Dependent> GetDependentList(int idEmployee)
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
    }
}
