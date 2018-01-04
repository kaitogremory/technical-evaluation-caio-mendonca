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
    public class DependentDataAccess : IDependentDataAccess
    {
        public List<Dependent> GetDependentList()
        {
            var list = new List<Dependent>()
            {
                //new Role() {Id= 1, Name = "Programador"},
                //new Role() {Id= 2, Name = "Tester"}
            };

            return list;
        }     
    }
}
