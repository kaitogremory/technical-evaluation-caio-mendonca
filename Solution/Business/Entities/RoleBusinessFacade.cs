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
    public class RoleBusinessFacade
    {
        private IRoleDataAccess _IRoleDataAccess;

        public RoleBusinessFacade(IRoleDataAccess RoleDataAccess)
        {
            _IRoleDataAccess = RoleDataAccess;
        }

        public virtual List<Role> GetRoleList()
        {
            try
            {
                var list = _IRoleDataAccess.GetRoleList();
                return list;
            }
            
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
