using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class EmployeeRegisterController : ApplicationController
    {
        public ActionResult Index(int? id)
        {
            if(id.HasValue)
            {
                ViewBag.Title = "Editar Empregado";
                ViewBag.Employee = base.GetEmployeeById(id.Value);
            }
            else
            {
                ViewBag.Title = "Novo Empregado";
                ViewBag.Employee = new Employee();
            }
            
            ViewBag.RoleList = base.GetRoleList();
            
            return View();
        }       
    }
}