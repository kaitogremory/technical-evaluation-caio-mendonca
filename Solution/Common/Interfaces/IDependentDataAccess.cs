using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDependentDataAccess
    {
        List<Dependent> GetDependentList(int idEmployee);
        void Insert(Dependent dep);
        void Delete(int idDependent);
        void DeleteByEmployee(int idEmployee);
    }
}
