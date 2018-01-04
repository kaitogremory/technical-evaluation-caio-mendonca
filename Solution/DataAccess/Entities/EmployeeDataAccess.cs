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
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>() 
            { 
                new Employee() { Id = 1, Name = "Caio Mendonça", Birth = new DateTime(), Email = "kaito.mendonca@gmail.com", Genre = EnumGenre.Male, Role = new Role() {Id = 1, Name = "Programmer"} },
                new Employee() { Id = 2, Name = "Kurogane Kaito", Birth = new DateTime(), Email = "kurogane.kaito@gmail.com", Genre = EnumGenre.Female, Role = new Role() {Id = 2, Name = "Tester"} }
            };

            return list;
        }

        public Employee GetEmployeeById(int idEmployee)
        {
            var _employee = new Employee()
            {
                Id = 2,
                Birth = new DateTime(1992, 12, 15),
                Email = "kaito.mendonca@gmail.com",
                Genre = EnumGenre.Male,
                Name = "Kaito",
                Role = new Role() { Id = 2, Name = "Programmer" }
            };

            return _employee;
        }
        
        public void Save(Employee register)
        {

        }

        public void Delete(int idEmployee)
        {

        }
    }
}
