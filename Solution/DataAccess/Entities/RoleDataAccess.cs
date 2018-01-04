using Common.Entities;
using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class RoleDataAccess : IRoleDataAccess
    {
        public List<Role> GetRoleList()
        {
            var list = new List<Role>()
            {
                new Role() {Id= 1, Name = "Programador"},
                new Role() {Id= 2, Name = "Tester"}
            };

            return list;
        }     
    }
}
