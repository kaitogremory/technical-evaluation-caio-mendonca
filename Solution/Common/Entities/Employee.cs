using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{

    public class Employee
    {
        public Employee() 
        {
            this.DepedentList = new List<Dependent>();
            this.Genre = null;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EnumGenre? Genre { get; set; }
        public DateTime Birth { get; set; }
        public Role Role { get; set; }
        public List<Dependent> DepedentList { get; set; }
    }
}
