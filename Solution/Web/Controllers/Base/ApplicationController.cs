using Common.Entities;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers.Base
{
    public class ApplicationController : Controller
    {
        #region [ Services ]
        protected List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>() 
            { 
                new Employee() { Id = 1, Name = "Caio Mendonça", Birth = new DateTime(), Email = "kaito.mendonca@gmail.com", Genre = EnumGenre.Male, Role = new Role() {Id = 1, Name = "Programmer"} },
                new Employee() { Id = 2, Name = "Kurogane Kaito", Birth = new DateTime(), Email = "kurogane.kaito@gmail.com", Genre = EnumGenre.Female, Role = new Role() {Id = 2, Name = "Tester"} }
            };

            return list;
        }

        protected List<Role> GetRoleList()
        {
            var list = new List<Role>()
            {
                new Role() {Id= 1, Name = "Programador"},
                new Role() {Id= 2, Name = "Tester"}
            };

            return list;
        }

        protected Employee GetEmployeeById(int id)
        {
            var _employee = new Employee()
            {
                Id = 2,
                Birth = new DateTime(1992, 12, 15),
                Email = "kaito.mendonca@gmail.com",
                Genre = EnumGenre.Male,
                Name = "Kaito",
                Role = new Role() { Id = 2, Name = "Programmer"}
            };

            return _employee;
        }
        #endregion

        #region [ Util ]
        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData["Model"] = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
}