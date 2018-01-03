using Common.Entities;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class EmployeeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeTable()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            model.EmployeeList = new List<Employee>() 
            { 
                new Employee() { Id = 1, Name = "Caio Mendonça", Birth = new DateTime(), Email = "kaito.mendonca@gmail.com", Genre = EnumGenre.Male, Role = new Role() {Id = 1, Name = "Programmer"} },
                new Employee() { Id = 2, Name = "Kurogane Kaito", Birth = new DateTime(), Email = "kurogane.kaito@gmail.com", Genre = EnumGenre.Female, Role = new Role() {Id = 2, Name = "Tester"} }
            };

            string tableHtml = RenderRazorViewToString("Employee/EmployeeTable", model);

            return new JsonResult
            {
                Data =
                    new
                    {                        
                        register = new
                        {                            
                            tableHtml = tableHtml
                        }
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}